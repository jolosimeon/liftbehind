using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;

	public Vector3 tempPosition;
	public Vector3 startPosition;


	// Use this for initialization
	void Start () {

		tempPosition = transform.position;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempPosition.x += horizontalSpeed;
		tempPosition.y = Mathf.Sin (Time.realtimeSinceStartup * verticalSpeed) * amplitude + startPosition.y;
		transform.position = tempPosition;
	}

	void OnCollisionEnter(Collision collision)
	{

		transform.position = new Vector3(transform.position.x, 5, transform.position.z);
		if (collision.gameObject.tag == "Zombie")
		{
			amplitude = 3.0F;
			verticalSpeed = 1.5F;
			horizontalSpeed = 0.4F;
		}
	}

}





























