using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 *	Script is attached to the Building Elevator Door Game Object 
 */
public class ElevatorDoorManager : MonoBehaviour {

	public Text doorStateDisplay;


	public bool IsDoorOpen() {
		return doorOpen;
	}

	public void SetNumberPressesRequiredOpen(int numPressesRequired) {
		openMovementScale = Mathf.Abs(MAX_DOOR_OPEN_X - MAX_DOOR_CLOSE_X) 
			/ (float) numPressesRequired;
	}

	public void SetNumberPressesRequiredClose(int numPressesRequired) {
		closeMovementScale = Mathf.Abs (MAX_DOOR_OPEN_X - MAX_DOOR_CLOSE_X) 
			/ (float)numPressesRequired;
	}
		
	private static Vector3 OPEN_MOVEMENT_VECTOR = Vector3.right;
	private static Vector3 CLOSE_MOVEMENT_VECTOR = Vector3.left;
	private const float MAX_DOOR_OPEN_X = 2.0f;
	private const float MAX_DOOR_CLOSE_X = -2.0f;

	private float openMovementScale;
	private float closeMovementScale;
	private bool doorOpen;


	private void Start () {
		doorOpen = false;
		SetNumberPressesRequiredOpen (50);
		SetNumberPressesRequiredClose (50);
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
			OpenDoor ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
			CloseDoor ();
		}

		if (IsMaxOpened ()) {
			doorOpen = true;
			MakeExact ();
		} else if (IsMaxClosed ()) {
			doorOpen = false;
			MakeExact ();
		}

		DisplayDoorState ();
	}

	private void OpenDoor() {
		transform.Translate (OPEN_MOVEMENT_VECTOR * openMovementScale, Space.World);
	}

	private void CloseDoor() {
		transform.Translate (CLOSE_MOVEMENT_VECTOR * closeMovementScale, Space.World);
	}

	/*
	 * Alternative method of opening the door.
	 * Only one button would be used since it automatically
	 * toggles between closing and opening.
	 */
	private void MoveDoor() {
		Vector3 movement = (doorOpen) ? CLOSE_MOVEMENT_VECTOR : OPEN_MOVEMENT_VECTOR;
		float movementScale = (doorOpen) ? closeMovementScale : openMovementScale;
		transform.Translate (movement * movementScale, Space.World);
	}

	private bool IsMaxOpened() {
		return transform.position.x >= MAX_DOOR_OPEN_X;
	}

	private bool IsMaxClosed() {
		return transform.position.x <= MAX_DOOR_CLOSE_X;
	}


	private void MakeExact() {
		transform.position = new Vector3 (
			(IsDoorOpen()) ? MAX_DOOR_OPEN_X : MAX_DOOR_CLOSE_X,
			transform.position.y,
			transform.position.z
		);
	}

	private void DisplayDoorState() {
		if (IsDoorOpen ()) {
			doorStateDisplay.text = "OPEN";
			doorStateDisplay.color = Color.green;
		} else {
			doorStateDisplay.text = "CLOSED";
			doorStateDisplay.color = Color.red;
		}
	}
}
