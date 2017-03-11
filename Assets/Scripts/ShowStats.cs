using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour {
	int numOfSurvivorsSaved;

	// Use this for initialization
	void Start () {
		numOfSurvivorsSaved = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Semicolon)) {
			numOfSurvivorsSaved++;
		}
	}

	void OnGUI() {
		GUI.skin.textArea.fontSize = 18;
		GUI.skin.textArea.normal.background = null;
		GUI.skin.textArea.active.background = null;
		GUI.TextArea (new Rect (10,10, 300, 100), "Number of survivors saved: " + numOfSurvivorsSaved);
	}
}
