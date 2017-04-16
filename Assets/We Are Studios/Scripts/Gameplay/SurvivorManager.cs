using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *	Script is attached to the Survivor Game Object 
 */
public class SurvivorManager : RunningNPC {

	public GameRunManager gameRunManager;
    public AudioSource survivorAudio;
    public AudioClip scream;
    public AudioClip helpme;
    public AudioClip footsteps;
    public AudioClip run;

	public bool IsSaved() {
		return saved;
	}
		
	public void Reset() {
		base.Reset ();
		waiting = false;
		saved = false;
		dead = false;
	}

	private const float ELEVATOR_DOOR_BLOCK_Z = 3.6f;
	private const float ELEVATOR_DOOR_RAILS_Z = 4.6f;
	private const float ELEVATOR_DOOR_INSIDE_Z = 9.7f;

	private bool waiting;
	private bool dead;
	private bool saved;
    private bool playOnce = false;


	private void Start() {
		base.Start ();
		Reset ();
	}

	private void Update() {
		base.Update ();

		if (base.IsRunning () && IsTryingToGetSaved () && IsStuckOutsideDoor ()) {
			DoWait ();
		} else if (IsTryingToGetSaved () && waiting && IsDoorOpen ()) {
			DoContinueRun ();
		} else if (IsTryingToGetSaved () && IsInsideElevator ()) {
			DoSalute ();
			gameRunManager.NotifySurvivorSaved ();
		} 

		if (gameRunManager.IsSurvivorCaughtByZombie ()) {
			DoDie ();
		}
	}

	private bool IsTryingToGetSaved() {
		return !dead && !saved;
	}

	private bool IsStuckOutsideDoor() {
		return IsAtDoor () && !IsDoorOpen ();
	}

	private bool IsAtDoor() {
		return transform.position.z >= ELEVATOR_DOOR_BLOCK_Z
			&& transform.position.z <= ELEVATOR_DOOR_RAILS_Z;
	}

	private bool IsDoorOpen() {
		return gameRunManager.IsDoorOpen();
	}

	private void DoContinueRun() {
		waiting = false;
        if (!IsInsideElevator())
            survivorAudio.PlayOneShot(run);
        base.StartRun ();
		animator.Play ("sprint_00");
       
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z;
	}

	private void DoWait() {
        survivorAudio.PlayOneShot(helpme);
        base.StopRun ();
		waiting = true;
        animator.SetTrigger ("Wait");
        
	}

	private void DoSalute() {
		base.StopRun ();
		saved = true;
		transform.Rotate (new Vector3 (0, 180, 0));
		animator.Play ("pose_01");
	}

	private void DoDie() {
        if (!playOnce) {
            survivorAudio.PlayOneShot(scream);
            playOnce = true;
        }
        
        base.StopRun ();
		waiting = false;
		dead = true;
		animator.SetTrigger ("Dead");
	}
}
