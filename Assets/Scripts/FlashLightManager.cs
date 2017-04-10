using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Controls the flashlight and user point and click interactions.
 * Script is attached to the FirstPersonCharacter inside the FPS Player object.
 */
public class FlashlightManager : MonoBehaviour {
	private float DISTANCE_TO_SEE = 30;

	private Text interactionTooltip;
	private AudioClip soundTurnOn;
	private AudioClip soundTurnOff;
	public Light lightSource;

	void Start () {
		interactionTooltip = GameObject.Find ("Interaction Tooltip").GetComponent<Text> ();
		interactionTooltip.text = "";
	}

	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			ToggleFlashlight ();
		}

		Raycasting ();
	}

	void ToggleFlashlight() {
		lightSource.enabled = !lightSource.enabled;

		if (lightSource.enabled) {
			GetComponent<AudioSource> ().clip = soundTurnOn;
		} else {
			GetComponent<AudioSource> ().clip = soundTurnOff;
		}
	}

	void Raycasting() {
		Debug.DrawRay (this.transform.position, 
			this.transform.forward * DISTANCE_TO_SEE, Color.magenta);

		RaycastHit hitObject;
		if (Physics.Raycast (this.transform.position, 
			this.transform.forward, out hitObject, DISTANCE_TO_SEE)) {
			handleObject (hitObject.collider.gameObject);
		}
	}

	void handleObject(GameObject obj) {
		if (obj.tag == "Enemy") {
			handleEnemy (obj);
		} else if (obj.tag == "Survivor") {
			handleSurvivor (obj);
		} else if (obj.tag == "Interactive Object") {
			handleInteractiveObject (obj);
		} else {
			interactionTooltip.text = "";
		}
	}

	void handleEnemy(GameObject enemyObj) {
		Debug.Log ("FlashlightManager:handleEnemy: Enemy hit");
		ZombieController enemyManager = enemyObj.GetComponent<ZombieController> ();
		enemyManager.Startle ();
	}

	void handleSurvivor(GameObject survivorObj) {
		Debug.Log ("FlashlightManager:handleSurvivor: Survivor hit");
		SurvivorController survivorManager = survivorObj.GetComponent<SurvivorController> ();
		survivorManager.Startle ();
	}

	void handleInteractiveObject(GameObject interactiveObj) {
		Debug.Log ("FlashlightManager:handleInteractiveObject: Interactive object hit");

		switch (interactiveObj.name) {
			case "ElevatorUpButton": {
				handleElevatorUpButton (interactiveObj);
				break;
			}
		}
	}

	void handleElevatorUpButton(GameObject elevatorUpButton) {
		ElevatorFloorManager interactiveObjectManager = elevatorUpButton.GetComponent<ElevatorFloorManager> ();
		interactionTooltip.text = interactiveObjectManager.GetTooltip ();

		if (Input.GetMouseButtonDown(0)) {
			interactiveObjectManager.Interact();
		}
	}
}
