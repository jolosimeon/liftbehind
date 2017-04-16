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
    public AudioSource zombieSoloAudio;
    public AudioClip[] sounds;
    public float frequency = 7.0f;
    private float timeLeft;

	private void Start() {
        int selected = Random.Range(0, 5);
        zombieSoloAudio.PlayOneShot(sounds[selected]);
        timeLeft = frequency;
        base.Start ();
	}

	private void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            int selected = Random.Range(0, 5);
            zombieSoloAudio.PlayOneShot(sounds[selected]);
            timeLeft = frequency;
        }
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
		base.StopRun ();
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
}
