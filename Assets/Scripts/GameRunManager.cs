using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the gameplay logic
 * The script is attached to the Game Run Manager object.
 */
public class GameRunManager : MonoBehaviour {
	public ZombieManager zombie;
	public SurvivorManager survivor;

	private GUIStyle gameStatsStyle;
	private int numFloors;
	private int currentFloor;
	private int numSurvivorsNeeded;
	private int numSurvivorsSaved;


	/*
	 * Called by other scripts when the floor is changed 
	 */
	public void NotifyChangeFloor() {
		InitializeRandomFloor ();
	}

	private void Start () {
		gameStatsStyle = new GUIStyle ();
		gameStatsStyle.fontSize = 18;
		gameStatsStyle.fontStyle = FontStyle.Normal;
		GameInterfaceUtility.SetBackground (gameStatsStyle, null);
		GameInterfaceUtility.SetTextColor (gameStatsStyle, Color.white);

		numSurvivorsNeeded = 10;
		numSurvivorsSaved = 0;
	}

	private void Update () {
		
	}

	private void OnGUI() {
		DisplayGameStats ();
	}

	private void DisplayGameStats() {
		string numSavedMessage = "Number of survivors saved: " + numSurvivorsSaved;
		GUI.TextArea (new Rect (20, 20, 300, 100), numSavedMessage, gameStatsStyle);
	}

	/*
	 * Picks a random floor state. There are three (3) possible floor states:
	 * 1. Empty floor
	 * 2. Jumpscare floor (Zombie only)
	 * 3. Save the survivor floor (Zombie and Survivor)
	 */
	private void InitializeRandomFloor() {
//		int random = Random.Range(0, 3);
		int random = 2;

		switch (random) {
			case 0: {
				InitializeEmptyFloor ();
				break;
			}
			case 1:{
				InitializeJumpScareFloor ();
				break;
			}
			case 2:{
				InitializeSaveSurvivorFloor ();
				break;
			}
		}
	}

	/*
	 * Nothing to do in the floor, just an empty corridor
	 */
	private void InitializeEmptyFloor() {
		Debug.Log ("GameRunManager:InitializeEmptyFloor: Empty floor initialized");
		zombie.SetActive (false);
		survivor.SetActive (false);
	}

	/*
	 * Suprise player with zombie jumpscare when flashlight points at corridor
	 * Optional: Implement pressing of buttons on screen in proper order to push zombie away
	 */
	private void InitializeJumpScareFloor() {
		Debug.Log ("GameRunManager:InitializeJumpScareFloor: Jump scare floor initialized");
		zombie.SetActive (true);
		survivor.SetActive (false);

		// Zombie should be moved to jumpscare position only when flashlight is pointed
	}

	/*
	 * Save the player by letting him go inside elevator.
	 * The door must be closed before the zombie is able to enter.
	 * The survivor will always be ahead of the zombie.
	 */
	private void InitializeSaveSurvivorFloor() {
		Debug.Log ("GameRunManager:InitializeSaveSurvivorFloor: Save survivor floor initialized");
		zombie.SetActive (true);
		survivor.SetActive (true);

		zombie.MoveToStartingPosition ();
		survivor.Reset ();

		zombie.StartRun ();
		survivor.StartRun ();
	}
}
