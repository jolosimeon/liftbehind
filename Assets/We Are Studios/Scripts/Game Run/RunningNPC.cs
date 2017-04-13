using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class RunningNPC : MonoBehaviour {

	public void SetActive(bool active) {
		gameObject.SetActive (active);
	}

	public void SetMoveSpeed(float moveSpeed) {
		this.moveSpeed = moveSpeed;
	}

	public void StartRun() {
		running = true;
	}

	public void StopRun() {
		running = false;
	}

	public bool IsRunning() {
		return running;
	}
		
	protected void Start () {
		startingPosition = gameObject.transform.position;
		moveSpeed = DEFAULT_MOVE_SPEED;
		Reset ();
	}

	protected void Update () {
		if (running) {
			MoveForward ();
		}
	}

	protected void Reset() {
		MoveToStartingPosition ();
		running = false;
	}

	private void MoveToStartingPosition() {
		gameObject.transform.position = startingPosition;
	}

	private const float DEFAULT_MOVE_SPEED = 3.0f;

	private Vector3 startingPosition;
	private float moveSpeed;
	private bool running;


	private void MoveForward() {
		gameObject.transform.Translate (Vector3.forward 
			* moveSpeed * Time.deltaTime, Space.World);
	}


}
