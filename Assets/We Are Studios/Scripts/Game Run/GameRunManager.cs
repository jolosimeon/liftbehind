using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 *	Script is attached to the Game Run Manager Game Object 
 */
public class GameRunManager : MonoBehaviour {
	public GameOverManager gameOverManager;
	public ZombieGangManager zombieGang;
	public ZombieManager zombie;
	public SurvivorManager survivor;

	public Text floorNumberDisplay;
	public Text numberSavedDisplay;

	private int numFloors;
	private int currentFloor;
	private int numSurvivorsNeeded;
	private int numSurvivorsSaved;


	public void SetNumFloors(int numFloors) {
		this.numFloors = numFloors;
	}

	public void SetNumberOfSurvivorsNeeded(int numSurvivorsNeeded) {
		this.numSurvivorsNeeded = numSurvivorsNeeded;
	}

	public void NotifyGameObjectSeen() {
		// TODO: Implement this, transfer code from FlashlightManager
	}

	public void NotifyChangeFloor() {
		ClearFloor ();
		InitializeRandomFloor ();
	}
		
	public void NotifySurvivorSaved() {
		++numSurvivorsSaved;
	}
		
	public void NotifyZombieInElevator() {
		gameOverManager.EndGame ("A ZOMBIE WAS ABLE TO ENTER THE ELEVATOR");
	}

	private void ClearFloor() {
		zombie.StopRun ();
		survivor.Reset ();
	}

	private void Start () {
		SetNumFloors (10);
		currentFloor = 1;

		SetNumberOfSurvivorsNeeded (5);
		numSurvivorsSaved = 0;
	}

	private void Update () {
		DisplayGameStatistics ();
	}

	private void DisplayGameStatistics() {
		floorNumberDisplay.text = "FLOOR " + currentFloor + " / " + numFloors;
		numberSavedDisplay.text = numSurvivorsSaved + " / " + numSurvivorsNeeded + " SURVIVORS SAVED";
	}
		
	private void InitializeRandomFloor() {
//		int random = Random.Range(0, 3);
		int random = 2;

		switch (random) {
			case 0: {
				InitializeEmptyFloor ();
				break;
			}
			case 1: {
				InitializeJumpScareFloor ();
				break;
			}
			case 2: {
				InitializeSurvivorFloor ();
				break;
			}
		}
	}

	private void InitializeEmptyFloor() {
		zombieGang.SetActive (false);
		zombie.SetActive (false);
		survivor.SetActive (false);

		Debug.Log ("GameRunManager:InitializeEmptyFloor: Empty floor initialized");
	}
		
	private void InitializeJumpScareFloor() {
		zombieGang.SetActive (true);
		zombie.SetActive (false);
		survivor.SetActive (false);

		// Zombie gang should only start attack when pointed with flashlight

		Debug.Log ("GameRunManager:InitializeJumpScareFloor: Jump scare floor initialized");
	}

	private void InitializeSurvivorFloor() {
		zombieGang.SetActive (false);
		zombie.SetActive (true);
		survivor.SetActive (true);

		zombie.Reset ();
		survivor.Reset ();

		zombie.StartRun ();
		survivor.StartRun ();

		Debug.Log ("GameRunManager:InitializeSaveSurvivorFloor: Survivor floor initialized");
	}
}
