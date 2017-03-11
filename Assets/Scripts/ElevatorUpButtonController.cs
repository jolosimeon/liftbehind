using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUpButtonController : MonoBehaviour, IElevatorButton {

	public GameObject elevatorObject;

	float initialPosition;

	bool goingUp;
	bool goingToInitial;
	bool isInteractionInvoked;

	float TOP = 7;
	float INITIAL = 1.48f;
	float BOTTOM_START = -5;

	void Start () {
		initialPosition = elevatorObject.transform.position.y;
		goingUp = false;
		goingToInitial = false;
	}

	void Update () {
		if (isInteractionInvoked) {
			Debug.Log ("theafak");
			if (!goingUp && !goingToInitial) {
				goingUp = true;
			} else if (IsMaxUp()) {
				WarpToBottom();
				goingUp = false;
				goingToInitial = true; 
			} else if (IsAtInitial()) {
				goingToInitial = false;
				isInteractionInvoked = false;
			}

			if (goingUp || goingToInitial) {
				MoveUp();
			}
		}
	}

	public void Interact(){
		Debug.Log ("what");
		isInteractionInvoked = true;
	}


	bool IsMaxUp() {
		return goingUp && (elevatorObject.transform.position.y >= TOP);
	}

	bool IsAtInitial() {
		return goingToInitial && (elevatorObject.transform.position.y >= INITIAL);
	}

	void MoveUp() {
		elevatorObject.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}

	void WarpToBottom() {
		elevatorObject.transform.position = new Vector3(elevatorObject.transform.position.x, BOTTOM_START, elevatorObject.transform.position.z);
	}

	void MakeExactToInitial() {
		elevatorObject.transform.position = new Vector3(elevatorObject.transform.position.x, INITIAL, elevatorObject.transform.position.z);
	}
}
