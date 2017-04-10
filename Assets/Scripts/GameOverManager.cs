using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameOverManager : MonoBehaviour {
	public Light flashLight;
	public FirstPersonController player;
	public GameController gameController;

	bool isGameOver;

	float w_ratio;
	float h_ratio;

	float x;
	float y;
	float w;
	float h;

	// Use this for initialization
	void Start () {
		w_ratio = 0.3f;
		h_ratio = 0.2f;

		x = (Screen.width * (1 - w_ratio)) / 2;
		y = (Screen.height * (1 - h_ratio)) / 2;
		w = Screen.width * w_ratio;
		h = Screen.height * h_ratio;

		ResetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver && Input.GetKeyDown (KeyCode.Q)) { // Temporary Trigger
			isGameOver = !isGameOver;
		} else if (isGameOver && Input.GetKeyDown (KeyCode.Space)) {
			ResetGame ();
		}
	}

	void OnGUI() {
		if (isGameOver) {
			flashLight.enabled = false;
			flashLight.GetComponent<FlashlightManager> ().enabled = false;
			player.enabled = false;
			ShowGameOverHeader ();
			ShowSubHeader ();
		}
	}

	void PlayerLoss() {
		isGameOver = true;
	}

	void ShowGameOverHeader() {
		GUIStyle gameOverHeaderStyle = new GUIStyle ();
		gameOverHeaderStyle.fontSize = 60;
		gameOverHeaderStyle.fontStyle = FontStyle.Bold;
		gameOverHeaderStyle.alignment = TextAnchor.MiddleCenter;

		gameOverHeaderStyle.normal.background = null;
		gameOverHeaderStyle.active.background = null;
		gameOverHeaderStyle.hover.background = null;
		gameOverHeaderStyle.focused.background = null;

		gameOverHeaderStyle.normal.textColor = Color.red;
		gameOverHeaderStyle.active.textColor = Color.red;
		gameOverHeaderStyle.hover.textColor = Color.red;
		gameOverHeaderStyle.focused.textColor = Color.red;



		GUI.TextArea(new Rect(x, y, w, h), "GAME OVER", gameOverHeaderStyle);
	}

	void ShowSubHeader() {
		GUIStyle gameOverSubHeaderStyle = new GUIStyle ();
		gameOverSubHeaderStyle.fontSize = 25;
		gameOverSubHeaderStyle.fontStyle = FontStyle.Normal;
		gameOverSubHeaderStyle.alignment = TextAnchor.MiddleCenter;

		gameOverSubHeaderStyle.normal.background = null;
		gameOverSubHeaderStyle.active.background = null;
		gameOverSubHeaderStyle.hover.background = null;
		gameOverSubHeaderStyle.focused.background = null;

		gameOverSubHeaderStyle.normal.textColor = Color.grey;
		gameOverSubHeaderStyle.active.textColor = Color.grey;
		gameOverSubHeaderStyle.hover.textColor = Color.grey;
		gameOverSubHeaderStyle.focused.textColor = Color.grey;


		GUI.TextArea(new Rect(x, y + 50, w, h),
			"Press the spacebar to restart", gameOverSubHeaderStyle);
	}

	void ResetGame() {
		isGameOver = false;
		player.enabled = true;
		flashLight.enabled = true;
		flashLight.GetComponent<FlashlightManager> ().enabled = true;

		// Reset Jolo's Script
		gameController.SendMessage("Start");
	}
}
