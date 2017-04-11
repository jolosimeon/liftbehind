using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RunningNPC : MonoBehaviour {
	private Vector3 startingPosition;
	private float moveSpeed;
	private bool running;
	private bool initialized = false;


	public void SetActive(bool active) {
		gameObject.SetActive (active);
		running = false;
	}

	public void MoveToStartingPosition() {
		gameObject.transform.position = startingPosition;
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
		if (!initialized) {
			startingPosition = gameObject.transform.position;
			initialized = true;
		} else {
			gameObject.transform.position = startingPosition;
		}

		moveSpeed = 3.0f;
		running = false;
	}

	protected void Update () {
		if (running) {
			MoveForward ();
		}
	}

	private void MoveForward() {
		gameObject.transform.Translate (Vector3.forward 
			* moveSpeed * Time.deltaTime, Space.World);
	}

	protected void SetMoveSpeed(float moveSpeed) {
		this.moveSpeed = moveSpeed;
	}
}
