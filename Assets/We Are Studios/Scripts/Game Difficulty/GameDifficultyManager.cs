using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDifficultyManager : MonoBehaviour {
	private const float EASY_ZOMBIE_SPEED = 1.0f;
	private const int EASY_NUMBER_PRESSES_OPEN = 10;
	private const int EASY_NUMBER_PRESSES_CLOSE = 10;

	private const float MEDIUM_ZOMBIE_SPEED = 2.0f;
	private const int MEDIUM_NUMBER_PRESSES_OPEN = 50;
	private const int MEDIUM_NUMBER_PRESSES_CLOSE = 50;

	private const float HARD_ZOMBIE_SPEED = 3.0f;
	private const int HARD_NUMBER_PRESSES_OPEN = 90;
	private const int HARD_NUMBER_PRESSES_CLOSE = 90;

	private float zombieSpeed;
	private int numPressesOpen;
	private int numPressesClose;


	public float GetZombieSpeed() {
		return zombieSpeed;
	}

	public int GetNumberOfPressesOpen() {
		return numPressesOpen;
	}

	public int GetNumberOfPressesClose() {
		return numPressesClose;
	}
		
	public void SelectEasy() {
		zombieSpeed = EASY_ZOMBIE_SPEED;
		numPressesOpen = EASY_NUMBER_PRESSES_OPEN;
		numPressesClose = EASY_NUMBER_PRESSES_CLOSE;
		SceneManager.LoadScene ("Gameplay");
	}

	public void SelectMedium() {
		zombieSpeed = MEDIUM_ZOMBIE_SPEED;
		numPressesOpen = MEDIUM_NUMBER_PRESSES_OPEN;
		numPressesClose = MEDIUM_NUMBER_PRESSES_CLOSE;
		SceneManager.LoadScene ("Gameplay");
	}

	public void SelectHard() {
		zombieSpeed = HARD_ZOMBIE_SPEED;
		numPressesOpen = HARD_NUMBER_PRESSES_OPEN;
		numPressesClose = HARD_NUMBER_PRESSES_CLOSE;
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
