using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *	Script is attached to the Game Run Manager Game Object 
 */
public class GameRunManager : MonoBehaviour {
	public FlashlightManager flashlightManager;
	public ElevatorDoorManager elevatorDoorManager;
	public ElevatorFloorManager elevatorFloorManager;

	public ZombieGangManager zombieGang;
	public ZombieManager zombie;
	public SurvivorManager survivor;

	public GameOverManager gameOverManager;

	public Text floorNumberDisplay;
	public Text numberSavedDisplay;
	public Text tooltipDisplay;


	public void SetNumFloors(int numFloors) {
		this.numFloors = numFloors;
	}

	public void SetNumberOfSurvivorsNeeded(int numSurvivorsNeeded) {
		this.numSurvivorsNeeded = numSurvivorsNeeded;
	}

	public void NotifyGameObjectSeen(GameObject obj) {
		switch (obj.tag) {
			case ENEMY_TAG: {
				break;
			}
				
			case SURVIVOR_TAG: {
				break;
			}
				
			case INTERACTIVE_OBJECT_TAG: {
				if (obj.name == ELEVATOR_UP_BUTTON_NAME) {
					HandleElevatorUpButton ();
				}
				break;
			}

			default: {
				DisplayTooltip ("");
				break;
			}
		}
	}

	public void NotifyChangeFloor() {
		ClearFloor ();
		InitializeRandomFloor ();
	}
		
	public void NotifySurvivorSaved() {
		++numSurvivorsSaved;
	}
		
	public void NotifyZombieInElevator() {
//		gameOverManager.EndGame ("A ZOMBIE WAS ABLE TO ENTER THE ELEVATOR");
		SceneManager.LoadScene ("Game Over");
	}

	public bool IsSurvivorCaughtByZombie() {
		return Mathf.Abs (zombie.transform.position.z - survivor.transform.position.z) 
			<= CAUGHT_DISTANCE;
	}

	public bool IsDoorOpen() {
		return elevatorDoorManager.IsDoorOpen ();
	}

	public bool IsChangingFloor() {
		return elevatorFloorManager.IsChangingFloor ();
	}

	private const float CAUGHT_DISTANCE = 1.5f;
	private const string ENEMY_TAG = "Enemy";
	private const string SURVIVOR_TAG = "Survivor";
	private const string INTERACTIVE_OBJECT_TAG = "Interactive Object";
	private const string ELEVATOR_UP_BUTTON_NAME = "Building Elevator Go Up Button"; 

	private int numFloors;
	private int currentFloor;
	private int numSurvivorsNeeded;
	private int numSurvivorsSaved;


	private void HandleElevatorUpButton() {
		DisplayTooltip (elevatorFloorManager.GetTooltip ());

		if (Input.GetMouseButton (0)) {
			elevatorFloorManager.Interact ();
		}
	}

	private void DisplayTooltip(string message) {
		tooltipDisplay.text = message;
	}

	private void ClearFloor() {
		zombie.StopRun ();
		survivor.Reset ();
	}

	private void Start () {
		survivor.SetMoveSpeed (3.0f);
		zombie.SetMoveSpeed (1.0f);

		SetNumFloors (10);
		currentFloor = 1;

		SetNumberOfSurvivorsNeeded (5);
		numSurvivorsSaved = 0;
	}

	private void Update () {
		if (Input.GetMouseButtonDown (1)) {
			flashlightManager.ToggleFlashlight ();
		}

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

//	private void Awake() {
//		DontDestroyOnLoad (transform.gameObject);
//	}
}
