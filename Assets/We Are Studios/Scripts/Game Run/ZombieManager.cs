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
	private static float JUMP_SCARE_X = 0f;
	private static float JUMP_SCARE_Y = 0f;
	private static float JUMP_SCARE_Z = 0f;

	public GameRunManager gameRunManager;
	public SurvivorManager survivor;


	private void Start() {
		base.Start ();
	}

	private void Update() {
		base.Update ();

		if (base.IsRunning() && IsSurvivorCaught ()) {
			base.StopRun ();
			animator.SetTrigger ("Eat");
			survivor.Die ();
		}
			
		// Start attack animation
		if (Mathf.Abs(transform.position.z - ELEVATOR_DOOR_INSIDE_Z) < 2) {
			animator.SetTrigger("Attack");
		}

		if (IsInsideElevator ()) {
			base.StopRun ();
			gameRunManager.NotifyZombieInElevator ();
		}
	}

	IEnumerator Wait(float duration) {
		Debug.Log("Start Wait() function. The time is: " + Time.time);
		Debug.Log( "Float duration = "+duration);
		yield return new WaitForSeconds(duration);   //Wait
		Debug.Log("End Wait() function and the time is: " +Time.time);
	}
		
	private bool IsSurvivorCaught() {
		return Mathf.Abs (transform.position.z - survivor.transform.position.z) <= CAUGHT_DISTANCE;
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z;
	}
}
