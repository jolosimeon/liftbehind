using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


/**
 * Controls the game over actions such as displaying the game over
 * message and allowing the user to retry.
 * The script is attached to the Game Over Manager obect.
 */
public class GameOverManager : MonoBehaviour {
	public FirstPersonController player;
	public FlashlightManager flashlight;
	public Canvas gameOverCanvas;
	public Text gameOverHeader;
	public Text gameOverReason;
	public Text gameOverInstruction;

	private bool gameOver;

	public bool IsGameOver() {
		return gameOver;
	}

	public void EndGame(string reason) {
		gameOverReason.text = reason;

		DisableGameplay ();
		SetVisiblityGameOverMessage (true);
		flashlight.SetEnabled (false);
		flashlight.RotateToInitialRotation ();
		gameOver = true;
	}
		
	private void DisableGameplay() {
		player.enabled = false;
	}

	private void SetVisiblityGameOverMessage(bool visible) {
		gameOverCanvas.enabled = visible;
	}

	void OnGUI() {
		if (gameOver) {
//			DisplayGameOverMessage ("Game Over", "Press the spacebar to restart");
		}
	}

	private void Start() {
		gameOverHeader.text = "GAME OVER";
		gameOverReason.text = "";
		gameOverInstruction.text = "Press the spacebar to restart the game";

		gameOver = false;
		SetVisiblityGameOverMessage (false);
	}

	private void Update() {
		if (IsGameOver() && Input.GetKeyDown(KeyCode.Space)) {
			Retry ();
		}
	}

	private void DisplayGameOverMessage(string header, string reason, string instruction) {
		
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
