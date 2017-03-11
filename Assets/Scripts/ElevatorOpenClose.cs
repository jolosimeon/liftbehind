using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpenClose : MonoBehaviour {
	private float MAX_CLOSE = -2.0f;
	private float MAX_OPEN = 2.0f;

	private bool isOpened;
	private Vector3 movementDirection;


	// Use this for initialization
	void Start () {
		isOpened = false;
		movementDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			isOpened = !isOpened;

			movementDirection = (isOpened) 
				? Vector3.right // Opening door by moving to the left
				: Vector3.left;  // Closing door by moving to the right
		} 

		if (IsMaxOpen ()) { // Stop opening door
			movementDirection = Vector3.zero;
			MakeExactOpen ();
		} else if (IsMaxClose ()) { // Stop closing door
			movementDirection = Vector3.zero;
			MakeExactClose ();
		}
			
		transform.Translate(movementDirection * Time.deltaTime, Space.World); // Check if Space.Self is correct
	}

	bool IsMaxOpen() {
		return movementDirection.Equals(Vector3.right) && transform.position.x >= MAX_OPEN; 
	}

	void MakeExactOpen() { 
		transform.position = new Vector3 (MAX_OPEN, transform.position.y, transform.position.z);
	}

	bool IsMaxClose() {
		return movementDirection.Equals (Vector3.left) && transform.position.x <= MAX_CLOSE;
	}

	void MakeExactClose() {
		transform.position = new Vector3 (MAX_CLOSE, transform.position.y, transform.position.z);
	}
}
