using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the survivor's action, spawning, etc.
 * The script is attached to the survivor object.
 */
public class SurvivorManager : RunningNPC {
	private static float ELEVATOR_DOOR_BLOCK_Z = 3.6f;
	private static float ELEVATOR_DOOR_RAILS_Z = 4.6f;
	private static float ELEVATOR_DOOR_INSIDE_Z = 9.7f;

	public GameRunManager gameRunManager;
	public ElevatorDoorManager elevatorDoorManager;
	private Animator animator;
	private bool saved;

	// TODO: Fix bug where dead survivor can still run

	public void Die() {
		base.StopRun ();
		animator.SetTrigger ("Dead");
		Debug.Log ("SurvivorManager:Die: Survivor is dead");
	}

	public bool IsSaved() {
		return saved;
	}
		
	public void Reset() {
		base.MoveToStartingPosition ();
		saved = false;
		ResetAnimation ();
	}

	private void ResetAnimation() {
		Debug.Log ("SurvivorManager:ResetAnimation: Resetting survivor animation");
		animator.Play ("Entry");
		animator.Rebind ();
	}

	private void Start() {
		base.Start ();
		base.SetMoveSpeed (3.0f);
		animator = GetComponent<Animator> ();
	}

	private void Update() {
		base.Update ();

		if (!saved && base.IsRunning () && IsAtDoor () && !IsDoorOpen ()) {
			Wait ();
		} else if (!saved && !base.IsRunning () && IsAtDoor () && IsDoorOpen ()) {
			ContinueRun ();
		}

		if (!saved && IsInsideElevator ()) {
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
