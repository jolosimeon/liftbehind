using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls the opening and closing of the elevator's door.
 * The script is attached to the Door object inside the Elevator object.
 */
public class ElevatorDoorManager : MonoBehaviour {
	private static float MAX_DOOR_OPEN = 2.0f;
	private static float MAX_DOOR_CLOSE = -2.0f;
	private static int NUM_PRESSES_OPEN = 50;
	private static int NUM_PRESSES_CLOSE = 50;
	private static float OPEN_MOVEMENT_SCALE = Mathf.Abs(MAX_DOOR_OPEN - MAX_DOOR_CLOSE) / NUM_PRESSES_OPEN;
	private static float CLOSE_MOVEMENT_SCALE = Mathf.Abs(MAX_DOOR_OPEN - MAX_DOOR_CLOSE) / NUM_PRESSES_CLOSE;
	private static Vector3 OPEN_MOVEMENT_VECTOR = Vector3.right;
	private static Vector3 CLOSE_MOVEMENT_VECTOR = Vector3.left;

	public Text doorStateText;

	private bool doorOpened;


	public bool IsDoorOpen() {
		return doorOpened;
	}

	private void Start () {
		doorOpened = false;
		doorStateText.text = "CLOSED";
		doorStateText.color = Color.red;
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			OpenDoor ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			CloseDoor ();
		}

		if (IsMaxOpened ()) {
			MakeExactOpen ();
			doorOpened = true;

			doorStateText.text = "OPEN";
			doorStateText.color = Color.green;
		} else if (IsMaxClosed ()) {
			MakeExactClose ();
			doorOpened = false;

			doorStateText.text = "CLOSED";
			doorStateText.color = Color.red;
		}
	}

	/*
	 * Alternative method of opening the door.
	 * Only one button would be used.
	 */
	private void MoveDoor() {
		Vector3 movement = (doorOpened) ? CLOSE_MOVEMENT_VECTOR : OPEN_MOVEMENT_VECTOR;
		float movementScale = (doorOpened) ? CLOSE_MOVEMENT_SCALE : OPEN_MOVEMENT_SCALE;
		transform.Translate (movement * movementScale, Space.World);
	}

	private void OpenDoor() {
		transform.Translate (OPEN_MOVEMENT_VECTOR * OPEN_MOVEMENT_SCALE, Space.World);
	}

	private void CloseDoor() {
		transform.Translate (CLOSE_MOVEMENT_VECTOR * CLOSE_MOVEMENT_SCALE, Space.World);
	}

	private bool IsMaxOpened() {
		return transform.position.x >= MAX_DOOR_OPEN;
	}

	private bool IsMaxClosed() {
		return transform.position.x <= MAX_DOOR_CLOSE;
	}

	private void MakeExactOpen() {
		transform.position = new Vector3 (MAX_DOOR_OPEN, transform.position.y, transform.position.z);
	}

	private void MakeExactClose() {
		transform.position = new Vector3 (MAX_DOOR_CLOSE, transform.position.y, transform.position.z);
	}
}
