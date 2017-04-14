using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


/**
 *	Script is attached to the Game Run Manager Game Object 
 */
public class GameRunManager : MonoBehaviour {
	public FlashlightManager flashlightManager;
	public ElevatorDoorManager elevatorDoorManager;
	public ElevatorFloorManager elevatorFloorManager;

	public FirstPersonController firstPerson;

	public ZombieGangManager zombieGang;
	public ZombieManager zombie;
	public SurvivorManager survivor;

	public Text floorNumberDisplay;
	public Text numberSavedDisplay;
	public Text numberSurvivorsDisplay;
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
		if (currentFloor == numFloors) {
			FinishGameRun ();
		} else {
			++currentFloor;
			ClearFloor ();

			int floorType = floorsToGenerate [currentFloor - 1];
			InitializeFloor (floorType);
		}
	}

	private void FinishGameRun() {
		if (numSurvivorsSaved >= numSurvivorsNeeded) {
			SceneManager.LoadScene ("Game Win");
		} else {
			reasonGameOver = "YOU FAILED TO RESCURE THE REQUIRED NUMBER OF SURVIVORS";
			SceneManager.LoadScene ("Game Over");
		}
	}
		
	public void NotifySurvivorSaved() {
		++numSurvivorsSaved;
	}
		
	public void NotifyZombieInElevator() {
		reasonGameOver = "A ZOMBIE WAS ABLE TO ENTER THE ELEVATOR";

		DisableFirstPerson ();
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

	public int GetNumberOfSurvivorsSaved() {
		return numSurvivorsSaved;
	}

	public string GetReasonGameOver() {
		return reasonGameOver;
	}

	private const float CAUGHT_DISTANCE = 1.5f;
	private const string ENEMY_TAG = "Enemy";
	private const string SURVIVOR_TAG = "Survivor";
	private const string INTERACTIVE_OBJECT_TAG = "Interactive Object";
	private const string ELEVATOR_UP_BUTTON_NAME = "Building Elevator Go Up Button"; 

	private const int EMPTY_FLOOR = 0;
	private const int JUMPSCARE_FLOOR = 1;
	private const int SURVIVOR_FLOOR = 2;

	private int numFloors;
	private int currentFloor;
	private int numSurvivorsNeeded;
	private int numSurvivorsSaved;
	private int numSurvivors;

	private int[] floorsToGenerate;


	private string reasonGameOver;

	private void HandleElevatorUpButton() {
		string tooltipMessage = (elevatorDoorManager.IsDoorOpen()) 
			? "Unable to go up while elevator is open" : elevatorFloorManager.GetTooltip ();
		DisplayTooltip (tooltipMessage);

		if (Input.GetMouseButton (0) && !elevatorDoorManager.IsDoorOpen()) {
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
		GameObject gameDifficultyManagerObject = GameObject.Find ("Game Difficulty Manager");
		GameDifficultyManager gameDifficultyManager = 
			gameDifficultyManagerObject.GetComponent<GameDifficultyManager> ();

		survivor.SetMoveSpeed (gameDifficultyManager.GetSurvivorSpeed());
		zombie.SetMoveSpeed (gameDifficultyManager.GetZombieSpeed());
		elevatorDoorManager.SetNumberPressesRequiredOpen (gameDifficultyManager.GetNumberOfPressesOpen ());
		elevatorDoorManager.SetNumberPressesRequiredClose (gameDifficultyManager.GetNumberOfPressesClose ());
		SetNumFloors (gameDifficultyManager.GetNumberOfFloors());
		SetNumberOfSurvivorsNeeded (gameDifficultyManager.GetNumberOfSurvivorsRequired());

		currentFloor = 1;
		numSurvivorsSaved = 0;
		reasonGameOver = null;

		InitializeFloorsToGenerate ();

		Debug.Log ("------ Floors to Generate ------");
		for (int i = 0; i < numFloors; i++) {
			if (floorsToGenerate [i] == EMPTY_FLOOR) {
				Debug.Log ("EMPTY FLOOR");
			} else if (floorsToGenerate [i] == JUMPSCARE_FLOOR) {
				Debug.Log ("JUMPSCARE FLOOR");
			} else if (floorsToGenerate [i] == SURVIVOR_FLOOR) {
				Debug.Log ("SURVIVOR FLOOR");
			} else {
				Debug.Log ("INVALID");
			}
		}
	}

	private void InitializeFloorsToGenerate() {
		floorsToGenerate = new int[numFloors];

		List<int> floorIndexList = new List<int> ();
		for (int i = 0; i < numFloors; i++) {
			floorIndexList.Add (i);
		}

		for (int i = 0; i < numSurvivorsNeeded; i++) {
			int floor = GetRemoveRandom (floorIndexList);
			floorsToGenerate [floor] = SURVIVOR_FLOOR;
		}

		numSurvivors = numSurvivorsNeeded;
		for (int i = 0; i < floorIndexList.Count(); i++) {
			int floor = GetRemoveRandom (floorIndexList);
			int floorType = Random.Range (0, 3);
			floorsToGenerate [floor] = floorType;

			if (floorType == SURVIVOR_FLOOR) {
				++numSurvivors;
			}
		}
	}

	private int GetRemoveRandom(List<int> floorIndexList) {
		int random = Random.Range (0, floorIndexList.Count ());
		int item = floorIndexList.ElementAt(random);
		floorIndexList.RemoveAt (random);

		return item;
	}

	private void Update () {
		if (Input.GetMouseButtonDown (1) && reasonGameOver == null) {
			flashlightManager.ToggleFlashlight ();
		}

		DisplayGameStatistics ();
	}

	private void DisplayGameStatistics() {
		floorNumberDisplay.text = "FLOOR " + currentFloor + " / " + numFloors;
		numberSavedDisplay.text = numSurvivorsSaved + " SURVIVORS SAVED";
		numberSurvivorsDisplay.text = "RESCUE AT LEAST " 
			+ numSurvivorsNeeded + " OUT OF " + numSurvivors;
	}
		
	private void InitializeFloor(int floor) {
		// TODO: Remove this after development
		floor = JUMPSCARE_FLOOR;

		switch (floor) {
			case EMPTY_FLOOR: {
				InitializeEmptyFloor ();
				break;
			}
				
			case JUMPSCARE_FLOOR: {
				InitializeJumpScareFloor ();
				break;
			}
				
			case SURVIVOR_FLOOR: {
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

	private void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	private void DisableFirstPerson() {
		firstPerson.GetComponent<FirstPersonController> ().enabled = false;
	}
}
