using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	float MOVE_SPEED;
	float ROTATE_SPEED;
	bool isClockwiseRotation;
	bool isMovingTowardsPlayer;

	// Use this for initialization
	void Start () {
		ROTATE_SPEED = 10;
		MOVE_SPEED = (float)GetRandomNumber (3.0, 10.0);
		if (transform.rotation.y > 90)
			isClockwiseRotation = true;
		else
			isClockwiseRotation = false;
		isMovingTowardsPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMovingTowardsPlayer) {
			transform.Translate (Vector3.forward * MOVE_SPEED * Time.deltaTime, Space.World);
			Debug.Log (transform.rotation.y);
			if (isClockwiseRotation) {
				if (transform.rotation.y > 90)
					transform.Rotate (0, ROTATE_SPEED * -1 * Time.deltaTime, 0);
			} else {
				if (transform.rotation.y < 90)
					transform.Rotate (0, ROTATE_SPEED * 1 * Time.deltaTime, 0);
			}
		}
	}

	// pasok dito pag may tumama
	void OnCollisionEnter(Collision col){
		//Debug.Log ("ABA SER MA TUMAMA SAKIN ZOMBI AKO");
	}
		
	public void Startle() {
		Debug.Log ("aray ko ser sabi ni zombie");
		//Destroy (this.gameObject);
		isMovingTowardsPlayer = true;
	}

	public double GetRandomNumber(double minimum, double maximum)
	{
		System.Random random = new System.Random();
		return random.NextDouble() * (maximum - minimum) + minimum;
	}
}
