using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the gameplay logic
 * The script is attached to the Game Run Manager object.
 */
public class GameRunManager : MonoBehaviour {

	private GUIStyle gameStatsStyle;
	private int numSurvivorsNeeded;
	private int numSurvivorsSaved;

	private void Start () {
		gameStatsStyle = new GUIStyle ();
		gameStatsStyle.fontSize = 18;
		gameStatsStyle.fontStyle = FontStyle.Normal;
		Utility.SetBackground (gameStatsStyle, null);
		Utility.SetTextColor (gameStatsStyle, Color.white);

		numSurvivorsNeeded = 10;
		numSurvivorsSaved = 0;
	}

	private void Update () {
		
	}

	private void OnGUI() {
		DisplayGameStats ();
	}

	private void DisplayGameStats() {
		string numSavedMessage = "Number of survivors saved hehe: " + numSurvivorsSaved;
		GUI.TextArea (new Rect (20, 20, 300, 100), numSavedMessage, gameStatsStyle);
	}
}
