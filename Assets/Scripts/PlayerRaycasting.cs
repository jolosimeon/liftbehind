using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour {

	public float distanceToSee;
	RaycastHit hitObject;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out hitObject, distanceToSee)) {
			//Debug.Log ("nanay mo");
			//Debug.Log ("HI: " + hitObject.collider.gameObject.name);
			if (hitObject.collider.gameObject.tag == "Enemy") {
				//Destroy (hitObject.collider.gameObject);
				Debug.Log ("enemy hit");

				//ZombieController enemy = hitObject.collider.GetComponent<ZombieController> ();
				ZombieController enemy = hitObject.collider.gameObject.GetComponent<ZombieController> ();
				enemy.Startle ();
			}
		}
	}
}
