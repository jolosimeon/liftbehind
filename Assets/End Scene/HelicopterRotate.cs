using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterRotate : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;

	public Vector3 tempPosition;
	public Vector3 startPosition;

	public float movementSpeed = 5.0f;

	// Use this for initialization
//	void Start () {
//		transform.Rotate(0.0f, -90.0f, 0.0f);
//	}

	void Update () {
		transform.position += Vector3.up * Time.deltaTime * movementSpeed;
	}
}





























