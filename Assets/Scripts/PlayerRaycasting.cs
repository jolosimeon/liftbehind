using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycasting : MonoBehaviour {

	public float distanceToSee;
	RaycastHit hitObject;

	Text interactionTooltipText;

	// Use this for initialization
	void Start () {
		interactionTooltipText = GameObject.Find ("Interaction Tooltip").GetComponent<Text> ();
		interactionTooltipText.text = "";
	}

	// Update is called once per frame
	void Update () {
		// laser action
		Debug.DrawRay (this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

		if (Physics.Raycast (this.transform.position, this.transform.forward, out hitObject, distanceToSee)) {
			GameObject objectHit = hitObject.collider.gameObject;
			if (objectHit.tag == "Enemy") {
				//Destroy (hitObject.collider.gameObject);
				Debug.Log ("enemy hit");
				ZombieController enemy = objectHit.GetComponent<ZombieController> ();
				enemy.Startle ();
			}
			else if (objectHit.tag == "Survivor") {
				//Destroy (hitObject.collider.gameObject);
				SurvivorController survivor = objectHit.GetComponent<SurvivorController> ();
				survivor.Startle ();
			}
			else if (objectHit.tag == "Interactive Object") {
				IActionObject actionObject = null;
				switch (objectHit.name) {
					case "ElevatorUpButton": actionObject = objectHit.GetComponent<ElevatorUpButtonController> ();break;
				}
				interactionTooltipText.text = actionObject.GetTooltip ();
				if (Input.GetMouseButtonDown (0)) {
					actionObject.Interact ();
				}
			}
			else {
				interactionTooltipText.text = "";
			}
		}
	}
}
