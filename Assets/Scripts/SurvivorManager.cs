using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the survivor's action, spawning, etc.
 * The script is attached to the survivor object.
 */
public class SurvivorManager : RunningNPC {
	private static float ELEVATOR_DOOR_BLOCK_Z = 3.75f;

	public ElevatorDoorManager elevatorDoorManager;
	private Animator animator;

	private void Start() {
		base.Start ();
		base.SetMoveSpeed (3.0f);
		animator = GetComponent<Animator> ();
	}

	private void Update() {
		base.Update ();

		if (IsAtDoor () && !IsDoorOpen()) {
			base.StopRun ();
			Wait ();
		}
	}


	private bool IsAtDoor() {
		return transform.position.z >= ELEVATOR_DOOR_BLOCK_Z;
	}

	private bool IsDoorOpen() {
		return elevatorDoorManager.IsDoorOpen();
	}

	private void Wait() {
		animator.SetTrigger ("Wait");
	}

	private void Die() {
		animator.SetTrigger ("Dead");
	}
}
