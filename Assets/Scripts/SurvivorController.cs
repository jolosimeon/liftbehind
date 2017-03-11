using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorController : MonoBehaviour {

	float MOVE_SPEED;
	bool isMovingTowardsPlayer;

	// Use this for initialization
	void Start () {
		MOVE_SPEED = (float)GetRandomNumber (3.0, 10.0);
		isMovingTowardsPlayer = false;
	}

	// Update is called once per frame
	void Update () {
		if (isMovingTowardsPlayer) {
			transform.Translate(Vector3.forward * MOVE_SPEED * Time.deltaTime, Space.World);
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
