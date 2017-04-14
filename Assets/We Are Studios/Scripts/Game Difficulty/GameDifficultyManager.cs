using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// TODO: Fix bug where player can go up even if door is open (INCLUDE WARNING)
// TODO: Fix bug where saved survivor passes through floor (AGAIN). Previous fix was to
//		 include in elevator object?
// TODO: Implement generating at least required number of survivor floors (USE INT ARRAY)
// TODO: Display total number of generated survivor floors 
// TODO: Health is door opened instead of health bar for door

public class GameDifficultyManager : MonoBehaviour {
	private const float EASY_ZOMBIE_SPEED = 0.5f;
	private const float EASY_SURVIVOR_SPEED = 3.0f;
	private const int EASY_NUMBER_PRESSES_OPEN = 10;
	private const int EASY_NUMBER_PRESSES_CLOSE = 10;
//	private const int EASY_NUMBER_FLOORS = 5;
	private const int EASY_NUMBER_FLOORS = 2;
	private const int EASY_NUMBER_SURVIVORS_REQUIRED = 1;

	private const float MEDIUM_ZOMBIE_SPEED = 1.0f;
	private const float MEDIUM_SURVIVOR_SPEED = 3.0f;
	private const int MEDIUM_NUMBER_PRESSES_OPEN = 50;
	private const int MEDIUM_NUMBER_PRESSES_CLOSE = 50;
	private const int MEDIUM_NUMBER_FLOORS = 10;
	private const int MEDIUM_NUMBER_SURVIVORS_REQUIRED = 5;

	private const float HARD_ZOMBIE_SPEED = 1.5f;
	private const float HARD_SURVIVOR_SPEED = 3.0f;
	private const int HARD_NUMBER_PRESSES_OPEN = 90;
	private const int HARD_NUMBER_PRESSES_CLOSE = 90;
	private const int HARD_NUMBER_FLOORS = 20;
	private const int HARD_NUMBER_SURVIVORS_REQUIRED = 10;

	private float zombieSpeed;
	private float survivorSpeed;
	private int numPressesOpen;
	private int numPressesClose;
	private int numFloors;
	private int numSurvivorsRequired;


	public float GetZombieSpeed() {
		return zombieSpeed;
	}

	public float GetSurvivorSpeed() {
		return survivorSpeed;
	}

	public int GetNumberOfPressesOpen() {
		return numPressesOpen;
	}

	public int GetNumberOfPressesClose() {
		return numPressesClose;
	}

	public int GetNumberOfFloors() {
		return numFloors;
	}

	public int GetNumberOfSurvivorsRequired() {
		return numSurvivorsRequired;
	}
		
	public void SelectEasy() {
		zombieSpeed = EASY_ZOMBIE_SPEED;
		survivorSpeed = EASY_SURVIVOR_SPEED;
		numPressesOpen = EASY_NUMBER_PRESSES_OPEN;
		numPressesClose = EASY_NUMBER_PRESSES_CLOSE;
		numFloors = EASY_NUMBER_FLOORS;
		numSurvivorsRequired = EASY_NUMBER_SURVIVORS_REQUIRED;
		SceneManager.LoadScene ("Gameplay");
	}

	public void SelectMedium() {
		zombieSpeed = MEDIUM_ZOMBIE_SPEED;
		survivorSpeed = MEDIUM_SURVIVOR_SPEED;
		numPressesOpen = MEDIUM_NUMBER_PRESSES_OPEN;
		numPressesClose = MEDIUM_NUMBER_PRESSES_CLOSE;
		numFloors = MEDIUM_NUMBER_FLOORS;
		numSurvivorsRequired = MEDIUM_NUMBER_SURVIVORS_REQUIRED;
		SceneManager.LoadScene ("Gameplay");
	}

	public void SelectHard() {
		zombieSpeed = HARD_ZOMBIE_SPEED;
		survivorSpeed = HARD_SURVIVOR_SPEED;
		numPressesOpen = HARD_NUMBER_PRESSES_OPEN;
		numPressesClose = HARD_NUMBER_PRESSES_CLOSE;
		numFloors = HARD_NUMBER_FLOORS;
		numSurvivorsRequired = HARD_NUMBER_SURVIVORS_REQUIRED;
		SceneManager.LoadScene ("Gameplay");
	}

	private void Start () {
		
	}
	

	private void Update () {
		
	}

	private void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
