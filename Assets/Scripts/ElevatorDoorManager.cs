using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorManager : MonoBehaviour {
	private static float MAX_DOOR_OPEN = 2.0f;
	private static float MAX_DOOR_CLOSE = -2.0f;
	private static int NUM_PRESSES_OPEN = 5;
	private static int NUM_PRESSES_CLOSE = 5;
	private static float OPEN_MOVEMENT_SCALE = Mathf.Abs(MAX_DOOR_OPEN - MAX_DOOR_CLOSE) / NUM_PRESSES_OPEN;
	private static float CLOSE_MOVEMENT_SCALE = Mathf.Abs(MAX_DOOR_OPEN - MAX_DOOR_CLOSE) / NUM_PRESSES_CLOSE;
	private static Vector3 OPEN_MOVEMENT_VECTOR = Vector3.right;
	private static Vector3 CLOSE_MOVEMENT_VECTOR = Vector3.left;

	private bool doorOpened;

	void Start () {
		doorOpened = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			MoveDoor ();

			if (IsMaxOpened ()) {
				MakeExactOpen ();
				doorOpened = true;
			} else if (IsMaxClosed ()) {
				MakeExactClose ();
				doorOpened = false;
			}
		}
	}

	void MoveDoor() {
		Vector3 movement = (doorOpened) ? CLOSE_MOVEMENT_VECTOR : OPEN_MOVEMENT_VECTOR;
		float movementScale = (doorOpened) ? CLOSE_MOVEMENT_SCALE : OPEN_MOVEMENT_SCALE;
		transform.Translate (movement * movementScale, Space.World);
	}

	bool IsMaxOpened() {
		return transform.position.x >= MAX_DOOR_OPEN;
	}

	bool IsMaxClosed() {
		return transform.position.x <= MAX_DOOR_CLOSE;
	}

	void MakeExactOpen() {
		transform.position = new Vector3 (MAX_DOOR_OPEN, transform.position.y, transform.position.z);
	}

	void MakeExactClose() {
		transform.position = new Vector3 (MAX_DOOR_CLOSE, transform.position.y, transform.position.z);
	}
}
