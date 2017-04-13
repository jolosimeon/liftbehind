using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour {
	public Text numberSavedDisplay;

	private GameRunManager gameRunManager;

	public void Start () {
		GameObject gameRunManagerObject = GameObject.Find ("Game Run Manager");
		gameRunManager = gameRunManagerObject.GetComponent<GameRunManager> ();

		int numSaved = gameRunManager.GetNumberOfSurvivorsSaved ();
		numberSavedDisplay.text = numSaved + " SURVIVOR"
		+ ((numSaved != 1) ? "s" : "") + " SAVED";

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		Destroy (gameRunManagerObject);
	}

	void Update () {
		
	}
}
