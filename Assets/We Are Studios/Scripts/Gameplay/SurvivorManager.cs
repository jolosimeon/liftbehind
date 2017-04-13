using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *	Script is attached to the Survivor Game Object 
 */
public class SurvivorManager : RunningNPC {

	public GameRunManager gameRunManager;


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
		base.StartRun ();
		animator.Play ("sprint_00");
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z;
	}

	private void DoWait() {
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
		base.StopRun ();
		waiting = false;
		dead = true;
		animator.SetTrigger ("Dead");

		Debug.Log ("SurvivorManager:Die: Survivor is dead");
	}
}
