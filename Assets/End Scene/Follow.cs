using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour
{
	public Transform target;


	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Chopper").transform;
	}
	void Update()
	{ 
		transform.LookAt(target);
		transform.Translate(Vector3.forward * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, 2, transform.position.z);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			SceneManager.LoadScene ("Game Win");
		}

	}
}