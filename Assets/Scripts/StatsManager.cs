using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {
	int numOfSurvivorsSaved;

	void Start () {
		numOfSurvivorsSaved = 0;
	}

	void Update () {

	}

	void AddSurvivor() {
		numOfSurvivorsSaved++;
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

		GUI.TextArea (new Rect (20,20, 300, 100), 
			"Number of survivors saved: " + numOfSurvivorsSaved, statsStyle);
	}
}
