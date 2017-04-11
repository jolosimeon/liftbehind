using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the survivor's action, spawning, etc.
 * The script is attached to the survivor object.
 */
public class SurvivorManager : RunningNPC {
	private static float ELEVATOR_DOOR_BLOCK_Z = 3.6f;

	public ElevatorDoorManager elevatorDoorManager;
	private Animator animator;


	public void Die() {
		base.StopRun ();
		animator.SetTrigger ("Dead");
		Debug.Log ("SurvivorManager:Die: Survivor is dead");
	}
		
	public void Reset() {
		base.MoveToStartingPosition ();
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

		if (base.IsRunning () && IsAtDoor () && !IsDoorOpen ()) {
			Wait ();
		} else if (!base.IsRunning () && IsAtDoor () && IsDoorOpen ()) {
			ContinueRun ();
		}
	}

	private void ContinueRun() {
		animator.Play ("sprint_00");
		base.StartRun ();
	}
		
	private bool IsAtDoor() {
		return transform.position.z >= ELEVATOR_DOOR_BLOCK_Z;
	}

	private bool IsDoorOpen() {
		return elevatorDoorManager.IsDoorOpen();
	}

	private void Wait() {
		base.StopRun ();
		animator.SetTrigger ("Wait");
		Debug.Log ("SurvivorManager:Wait: Survivor is waiting");
	}
}
