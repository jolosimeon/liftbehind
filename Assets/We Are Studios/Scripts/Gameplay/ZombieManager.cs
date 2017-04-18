using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the zombie's action, spawning, etc.
 * The script is attached to the zombie object.
 */
public class ZombieManager : RunningNPC {
	public GameRunManager gameRunManager;

	private static float ELEVATOR_DOOR_INSIDE_Z = 4.5f;
	private bool isDamagingElevator;


	private void Start() {
		base.Start ();
		isDamagingElevator = false;
	}

	private void Update() {
		base.Update ();

		if (gameRunManager.IsSurvivorCaughtByZombie()) {
			DoKillSurvivor ();
		}

		if (IsNearOpenElevatorDoor()) {
			DoAttackPlayer ();
		} 

		if (IsInsideElevator ()) {
			base.StopRun ();
			gameRunManager.NotifyZombieInElevator ();
		}
	}

	private void DoKillSurvivor() {
		//base.StopRun ();
		animator.SetTrigger ("Eat");
	}

	private bool IsNearOpenElevatorDoor() {
		return Mathf.Abs (transform.position.z - ELEVATOR_DOOR_INSIDE_Z) < 2;
	}

	private void DoAttackPlayer() {
		animator.SetTrigger("Attack");
	}

	private bool IsInsideElevator() {
		return transform.position.z >= ELEVATOR_DOOR_INSIDE_Z && gameRunManager.IsDoorOpen();
	}

	private void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Elevator Bar") {
			isDamagingElevator = true;
		} else
			isDamagingElevator = false;
	}

	public bool IsDamagingElevator(){
		return isDamagingElevator;
	}
}