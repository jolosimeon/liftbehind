using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 *  Script is attached to the Building Elevator Go Up Button Game Object 
 */
public class ElevatorFloorManager : MonoBehaviour {

	public GameRunManager gameRun;
	public GameObject elevator;
    public AudioSource elevatorAudio;
    public AudioClip goingUp;


	public void Interact() {
		Debug.Log ("Door closed completely: " + gameRun.elevatorDoorManager.IsExactClose ());

		if (!gameRun.elevatorDoorManager.IsDoorOpen() 
			&& !gameRun.elevatorDoorManager.IsExactClose()) {
			// DO NOTHING, Refactor this if possible, this is bad code design
		} else if (!changingFloor) {
			if (gameRun.survivor.IsSaved ()) {
				gameRun.survivor.Reset ();
			}

			ChangeFloor ();
		}
	}

	public string GetTooltip(){
		return "Press to go to the next floor";
	}

	public bool IsChangingFloor() {
		return changingFloor;
	}

	private Vector3 initialPosition;
	private Vector3 topMostPosition;
	private Vector3 bottomMostPosition;
	private bool changingFloor;
	private bool warpedToBottom;


	private void ChangeFloor() {
		changingFloor = true;
        elevatorAudio.PlayOneShot(goingUp);
        gameRun.elevatorDoorManager.MakeExact ();
		gameRun.elevatorDoorManager.SetEnableMovement (false);
	}

	private void Start () {
		initialPosition = elevator.transform.position; 
		topMostPosition = 
			new Vector3 (elevator.transform.position.x, 7, elevator.transform.position.z);
		bottomMostPosition = 
			new Vector3 (elevator.transform.position.x, -5, elevator.transform.position.z);

		Reset ();
	}

	private void Reset() {
		MakeExactToInitialPosition ();
		changingFloor = false;
		warpedToBottom = false;

		gameRun.elevatorDoorManager.MakeExact ();
		gameRun.elevatorDoorManager.SetEnableMovement (true);
	}

	private void MakeExactToInitialPosition() {
		elevator.transform.position = initialPosition;
	}

	private void Update () {
		if (IsAtTopMostPosition ()) {
			WarpToBottomPosition ();
		} else if (warpedToBottom && IsAtInitialPosition ()) {
			Reset ();

			gameRun.NotifyAtFloor ();
			//      bool enableDoorMove = (gameRun.GetCurrentFloorType () == GameRunManager.JUMPSCARE_FLOOR) ? false : true;
			//      gameRun.elevatorDoorManager.SetEnableMovement (enableDoorMove); 
		}

		if (changingFloor) {
			MoveUp ();
		}
	}

	private bool IsAtTopMostPosition() {
		return elevator.transform.position.y >= topMostPosition.y;
	}

	private void WarpToBottomPosition() {
		gameRun.NotifyChangeFloor ();
		elevator.transform.position = bottomMostPosition;
		warpedToBottom = true;
	}

	private bool IsAtInitialPosition() {
		return elevator.transform.position.y >= initialPosition.y;
	}

	private void MoveUp() {
		elevator.transform.Translate (Vector3.up * Time.deltaTime, Space.World);
	}

}
