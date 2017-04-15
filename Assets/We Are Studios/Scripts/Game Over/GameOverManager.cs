using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


/**
 *	Script is attached to the Game Over Manager Game Object 
 */
public class GameOverManager : MonoBehaviour {

	public Text gameOverReasonDisplay;
	public Text numberSavedDisplay;

	private	GameRunManager gameRunManager;

	private void Start() {
		GameObject gameRunManagerObject = GameObject.Find ("Game Run Manager");
		gameRunManager = gameRunManagerObject.GetComponent<GameRunManager> ();

		gameOverReasonDisplay.text = gameRunManager.GetReasonGameOver();

		int numSaved = gameRunManager.GetNumberOfSurvivorsSaved ();
		numberSavedDisplay.text = numSaved + " SURVIVOR"
		+ ((numSaved != 1) ? "s" : "") + " SAVED";

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		Destroy (gameRunManagerObject);
	}

	private void Update() {

	}

	public void Retry() {
		Debug.Log ("GameOverManager:Retry: Retry button clicked");
		SceneManager.LoadScene ("Gameplay");
	}

	public void BackToMenu() {
		GameObject gameDifficultyManagerObject = GameObject.Find ("Game Difficulty Manager");
		Destroy (gameDifficultyManagerObject);
		SceneManager.LoadScene ("Game Menu");
	}
}
