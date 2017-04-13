using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *	Script is attached to the Survivor Game Object 
 */
public class SurvivorManager : RunningNPC {

	public GameRunManager gameRunManager;
	public ElevatorDoorManager elevatorDoorManager;


	public void Die() {
		dead = true;
		base.StopRun ();
		animator.SetTrigger ("Dead");
		Debug.Log ("SurvivorManager:Die: Survivor is dead");
	}

	public bool IsSaved() {
		return saved;
	}
		
	public void Reset() {
		base.Reset ();
		saved = false;
		dead = false;
	}

	private const float ELEVATOR_DOOR_BLOCK_Z = 3.6f;
	private const float ELEVATOR_DOOR_RAILS_Z = 4.6f;
	private const float ELEVATOR_DOOR_INSIDE_Z = 9.7f;

	private bool dead;
	private bool saved;


	private void Start() {
		base.Start ();
		dead = false;
	}

	private void Update() {
		base.Update ();

		if (!dead && !saved && base.IsRunning () && IsAtDoor () && !IsDoorOpen ()) {
			Wait ();
		} else if (!dead && !saved && !base.IsRunning () && IsAtDoor () && IsDoorOpen ()) {
			ContinueRun ();
		}

		if (!dead && !saved && IsInsideElevator ()) {
			Save ();
		}
	}

	private bool IsAtDoor() {
		return transform.position.z >= ELEVATOR_DOOR_BLOCK_Z && transform.position.z <= ELEVATOR_DOOR_RAILS_Z;
	}

	private bool IsDoorOpen() {
		return elevatorDoorManager.IsDoorOpen();
	}

	private void ContinueRun() {
		animator.Play ("sprint_00");
		base.StartRun ();
		Debug.Log ("SurvivorManager:ContinueRun: Survivor continued running");
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z;
	}

	private void Wait() {
		base.StopRun ();
		animator.SetTrigger ("Wait");
		Debug.Log ("SurvivorManager:Wait: Survivor is waiting");
	}

	private void Save() {
		saved = true;
		base.StopRun ();
		transform.Rotate (new Vector3 (0, 180, 0));
		animator.Play ("pose_01");
		gameRunManager.NotifySurvivorSaved ();
		Debug.Log ("SurvivorManager:Saved: Survivor is saved");
	}
}
