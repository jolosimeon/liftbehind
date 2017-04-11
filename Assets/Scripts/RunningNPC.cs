using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNPC : MonoBehaviour {
	private static float MOVE_SPEED = 3.0f;

	private Vector3 startingPosition;
	private bool running;


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

	private void Start () {
		startingPosition = gameObject.transform.position;
	}

	private void Update () {
		if (running) {
			MoveForward ();
		}
	}

	private void MoveForward() {
		gameObject.transform.Translate (Vector3.forward 
			* MOVE_SPEED * Time.deltaTime, Space.World);
	}
}
