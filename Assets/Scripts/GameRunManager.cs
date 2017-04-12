using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls the gameplay logic
 * The script is attached to the Game Run Manager object.
 */
public class GameRunManager : MonoBehaviour {
	public GameOverManager gameOverManager;
	public ZombieManager zombie;
	public SurvivorManager survivor;
	public Text floorStatsText;
	public Text savedStatsText;

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

	/*
	 * Called by other scripts when a survivor is saved
	 */
	public void NotifySurvivorSaved() {
		++numSurvivorsSaved;
	}

	/*
	 * Called by other scripts when a zombie enters the elevator
	 */
	public void NotifyZombieInElevator() {
		gameOverManager.EndGame ("A ZOMBIE WAS ABLE TO ENTER THE ELEVATOR");
	}

	private void Start () {
		gameStatsStyle = new GUIStyle ();
		gameStatsStyle.fontSize = 18;
		gameStatsStyle.fontStyle = FontStyle.Normal;
		GameInterfaceUtility.SetBackground (gameStatsStyle, null);
		GameInterfaceUtility.SetTextColor (gameStatsStyle, Color.white);

		numFloors = 10;
		currentFloor = 1;
		numSurvivorsNeeded = 5;
		numSurvivorsSaved = 0;
	}

	private void Update () {
		
	}

	private void OnGUI() {
		DisplayGameStats ();
	}

	private void DisplayGameStats() {
		floorStatsText.text = "FLOOR " + currentFloor + " / " + numFloors;
		savedStatsText.text = numSurvivorsSaved + " / " + numSurvivorsNeeded + " SURVIVORS SAVED";
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
	 * Optional:
	 * The zombie has a health and your door also has a health
	 * 
	 * A letter or key will be flashed on the screen. The user must press that key to deal damage to the zombie.
	 * The door's health is constantly reducing  until the zombie is defeated. 
	 * If the door's health becomes zero then game over.
	 * 
	 * Decide whether to regen door's health at each floor. The purpose of the flashlight
	 * is to turn it off when going up levels and door's health is low.
	 * 
	 * This floor is the reason why its a bad idea to always keep elevator door open.
	 * If door is open and the level is a jumpscare floor, the player auto-loses.
	 * 
	 * Elevator cannot move up unstil zombie is defeated.
	 */
	private void InitializeJumpScareFloor() {
		Debug.Log ("GameRunManager:InitializeJumpScareFloor: Jump scare floor initialized");
		zombie.SetActive (true);
		survivor.SetActive (false);

		// Zombie should be moved to jumpscare position only when flashlight is pointed
		zombie.MoveToJumpScarePosition();
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

		zombie.Reset ();
		survivor.Reset ();

		zombie.StartRun ();
		survivor.StartRun ();
	}
}
