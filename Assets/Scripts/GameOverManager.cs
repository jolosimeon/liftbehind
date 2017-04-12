using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/**
 * Controls the game over actions such as displaying the game over
 * message and allowing the user to retry.
 * The script is attached to the Game Over Manager obect.
 */
public class GameOverManager : MonoBehaviour {
	public FirstPersonController player;
	public FlashlightManager flashlight;

	private GUIStyle messageHeaderStyle;
	private GUIStyle messageBodyStyle;
	private bool gameOver;


	public void EndGame() {
		DisableGameplay ();
		gameOver = true;
	}

	public bool IsGameOver() {
		return gameOver;
	}
		
	private void DisableGameplay() {
		player.enabled = false;
		flashlight.SetToInitialRotation ();
	}

	void OnGUI() {
		messageHeaderStyle = new GUIStyle ();
		messageHeaderStyle.fontSize = 60;
		messageHeaderStyle.fontStyle = FontStyle.Bold;
		messageHeaderStyle.alignment = TextAnchor.MiddleCenter;
		GameInterfaceUtility.SetBackground (messageHeaderStyle, null);
		GameInterfaceUtility.SetTextColor (messageHeaderStyle, Color.red);

		messageBodyStyle = new GUIStyle ();
		messageBodyStyle.fontSize = 25;
		messageBodyStyle.alignment = TextAnchor.MiddleCenter;
		GameInterfaceUtility.SetBackground (messageBodyStyle, null);
		GameInterfaceUtility.SetTextColor (messageBodyStyle, Color.white);
	
		if (gameOver) {
			DisplayGameOverMessage ("Game Over", "Press the spacebar to restart");
		}
	}

	private void Start() {
		gameOver = false;
	}

	private void Update() {
		if (IsGameOver() && Input.GetKeyDown(KeyCode.Space)) {
			Retry ();
		}
	}

	private void DisplayGameOverMessage(string header, string body) {
		float w_ratio = 0.3f;
		float h_ratio = 0.2f;

		float x = (Screen.width * (1 - w_ratio)) / 2;
		float y = (Screen.height * (1 - h_ratio)) / 2;
		float w = Screen.width * w_ratio;
		float h = Screen.height * h_ratio;

		GUI.TextArea (new Rect (x, y, w, h), header, messageHeaderStyle);
		GUI.TextArea (new Rect (x, y + 50, w, h), body, messageBodyStyle);
	}

	private void Retry() {
//		EnableGameplay ();
//		gameOver = false;

		// Reload the game using GameRunManager
	}

	private void EnableGameplay() {
		player.enabled = true;
		flashlight.enabled = true;
	}
}
