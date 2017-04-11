using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the elevator's changing of floors.
 * Script is attached to the ElevatorUpButton object.
 */
public class ElevatorFloorManager : MonoBehaviour, Interactable {
	public GameRunManager gameRunManager;
	public GameObject elevator;

	private Vector3 initialElevatorPosition;
	private Vector3 topElevatorPosition;
	private Vector3 bottomElevatorPosition;
	private bool changingFloor;
	private bool warped;

	/*
	 * Triggered when elevator button is pressed
	 */
	public void Interact() {
		if (!changingFloor) {
			ChangeFloor ();
		}
	}

	public string GetTooltip(){
		return "Press to go to the next floor";
	}

	private void ChangeFloor() {
		changingFloor = true;
	}

	private void Start () {
		initialElevatorPosition = elevator.transform.position; 
		topElevatorPosition = new Vector3 (elevator.transform.position.x,
			7, elevator.transform.position.z);
		bottomElevatorPosition = new Vector3 (elevator.transform.position.x,
			-5, elevator.transform.position.z);
		
		changingFloor = false;
		warped = false;
	}

	private void Update () {
		if (IsAtTop ()) {
			WarpToBottom ();
			warped = true;
		} else if (warped && IsAtInitial ()) {
			changingFloor = false;
			warped = false;
			MakeExactInitial ();
			gameRunManager.NotifyChangeFloor ();
		}
			
		if (changingFloor) {
			MoveUp ();
		}
	}

	private bool IsAtTop() {
		return elevator.transform.position.y >= topElevatorPosition.y;
	}

	private void WarpToBottom() {
		elevator.transform.position = bottomElevatorPosition;
	}

	private bool IsAtInitial() {
		return elevator.transform.position.y >= initialElevatorPosition.y;
	}

	private void MakeExactInitial() {
		elevator.transform.position = initialElevatorPosition;
	}

	private void MoveUp() {
		elevator.transform.Translate (Vector3.up * Time.deltaTime, Space.World);
	}
}
