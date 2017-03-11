using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowGameOver : MonoBehaviour {
	bool isGameOver;

	// Use this for initialization
	void Start () {
		isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			isGameOver = !isGameOver;
		}
	}

	void OnGUI() {
		if (isGameOver) {
			GUIStyle gameOverHeaderStyle = new GUIStyle ();
			gameOverHeaderStyle.fontSize = 60;
			gameOverHeaderStyle.fontStyle = FontStyle.Bold;
	
			gameOverHeaderStyle.normal.background = null;
			gameOverHeaderStyle.active.background = null;
			gameOverHeaderStyle.hover.background = null;
			gameOverHeaderStyle.focused.background = null;

			gameOverHeaderStyle.normal.textColor = Color.red;
			gameOverHeaderStyle.active.textColor = Color.red;
			gameOverHeaderStyle.hover.textColor = Color.red;
			gameOverHeaderStyle.focused.textColor = Color.red;

			GUI.TextArea(new Rect(330, 300, 320, 70), "GAME OVER", gameOverHeaderStyle);

			GUIStyle gameOverSubHeaderStyle = new GUIStyle ();
			gameOverSubHeaderStyle.fontSize = 25;
			gameOverSubHeaderStyle.fontStyle = FontStyle.Normal;

			gameOverSubHeaderStyle.normal.background = null;
			gameOverSubHeaderStyle.active.background = null;
			gameOverSubHeaderStyle.hover.background = null;
			gameOverSubHeaderStyle.focused.background = null;

			gameOverSubHeaderStyle.normal.textColor = Color.grey;
			gameOverSubHeaderStyle.active.textColor = Color.grey;
			gameOverSubHeaderStyle.hover.textColor = Color.grey;
			gameOverSubHeaderStyle.focused.textColor = Color.grey;

			GUI.TextArea(new Rect(350, 400, 320, 70), "Press the spacebar to restart", gameOverSubHeaderStyle);
		}
	}
}
