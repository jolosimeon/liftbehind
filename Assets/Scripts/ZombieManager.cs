using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the zombie's action, spawning, etc.
 * The script is attached to the zombie object.
 */
public class ZombieManager : RunningNPC {
	public static float CAUGHT_DISTANCE = 1.5f;

	private static float ELEVATOR_DOOR_INSIDE_Z = 4.5f;

	public GameRunManager gameRunManager;
	public SurvivorManager survivor;

	private Animator animator;


	public void DoJumpScare () {
		Debug.Log ("ZombieManager:DoJumpScare: Doing jump scare");
	}

	public void Reset() {
		base.MoveToStartingPosition ();
		ResetAnimation ();
	}

	private void ResetAnimation() {
		Debug.Log ("ZombieManager:ResetAnimation: Resetting survivor animation");
		animator.Stop ();
		animator.Play ("Entry");
		animator.Rebind ();
	}

	private void Start() {
		base.Start ();
		base.SetMoveSpeed (1.0f);
		animator = GetComponent<Animator> ();
	}

	private void Update() {
		base.Update ();

		if (base.IsRunning() && IsSurvivorCaught ()) {
			base.StopRun ();
			survivor.Die ();
		}

		if (IsInsideElevator ()) {
			base.StopRun ();
			gameRunManager.NotifyZombieInElevator ();
		}
	}
		
	private bool IsSurvivorCaught() {
		return Mathf.Abs (transform.position.z - survivor.transform.position.z) <= CAUGHT_DISTANCE;
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z;
	}
}
