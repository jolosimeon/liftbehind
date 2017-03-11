using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpenClose : MonoBehaviour {
	private float MAX_CLOSE = -2.0f;
	private float MAX_OPEN = 2.0f;

	private int numOfPushesRequired;
	float scale;

	void Start () {
		numOfPushesRequired = 50;
		scale = (MAX_OPEN - MAX_CLOSE) / numOfPushesRequired;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			transform.Translate(Vector3.right * scale, Space.World);
		} else if (Input.GetKeyDown(KeyCode.X)) {
			transform.Translate(Vector3.left * scale, Space.World);
		}

		if (IsMaxOpen()) { // Stop opening door
			MakeExactOpen ();
		} else if (IsMaxClose ()) { // Stop closing door
			MakeExactClose ();
		}
	}

	bool IsMaxOpen() {
		return transform.position.x >= MAX_OPEN; 
	}

	void MakeExactOpen() { 
		transform.position = new Vector3 (MAX_OPEN, transform.position.y, transform.position.z);
	}

	bool IsMaxClose() {
		return transform.position.x <= MAX_CLOSE;
	}

	void MakeExactClose() {
		transform.position = new Vector3 (MAX_CLOSE, transform.position.y, transform.position.z);
	}
}
