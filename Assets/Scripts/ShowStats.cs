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

		GUIStyle statsStyle = new GUIStyle ();
		statsStyle.fontSize = 18;
		statsStyle.fontStyle = FontStyle.Normal;

		statsStyle.normal.background = null;
		statsStyle.active.background = null;
		statsStyle.hover.background = null;
		statsStyle.focused.background = null;

		statsStyle.normal.textColor = Color.white;
		statsStyle.active.textColor = Color.white;
		statsStyle.hover.textColor = Color.white;
		statsStyle.focused.textColor = Color.white;

		GUI.TextArea (new Rect (10,10, 300, 100), 
			"Number of survivors saved: " + numOfSurvivorsSaved, statsStyle);
	}
}
