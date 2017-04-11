using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the zombie's action, spawning, etc.
 * The script is attached to the zombie object.
 */
public class ZombieManager : RunningNPC {
	public static float CAUGHT_DISTANCE = 1.5f;

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
		base.SetMoveSpeed (2.0f);
		animator = GetComponent<Animator> ();
	}

	private void Update() {
		base.Update ();

		if (base.IsRunning() && IsSurvivorCaught ()) {
			base.StopRun ();
			survivor.Die ();
		}
	}

	private bool IsSurvivorCaught() {
		return Mathf.Abs (transform.position.z - survivor.transform.position.z) <= CAUGHT_DISTANCE;
	}
}
