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

	public Light lightSource;

	private Quaternion initialRotation;
	private Text interactionTooltip;
	private AudioClip soundTurnOn;
	private AudioClip soundTurnOff;


	public void SetEnabled(bool enabled) {
		lightSource.enabled = enabled;
	}

	public void SetToInitialRotation() {
		transform.rotation = initialRotation;
	}

	private void Start () {
		interactionTooltip = GameObject.Find ("Interaction Tooltip").GetComponent<Text> ();
		interactionTooltip.text = "";
		initialRotation = transform.rotation;
	}

	private void Update () {
		if (Input.GetMouseButtonDown (1)) {
			ToggleFlashlight ();
		}

		Raycasting ();
	}

	private void ToggleFlashlight() {
		lightSource.enabled = !lightSource.enabled;

//		if (lightSource.enabled) {
//			GetComponent<AudioSource> ().clip = soundTurnOn;
//		} else {
//			GetComponent<AudioSource> ().clip = soundTurnOff;
//		}
	}

	private void Raycasting() {
		Debug.DrawRay (this.transform.position, 
			this.transform.forward * DISTANCE_TO_SEE, Color.magenta);

		RaycastHit hitObject;
		if (Physics.Raycast (this.transform.position, 
			this.transform.forward, out hitObject, DISTANCE_TO_SEE)) {
			handleObject (hitObject.collider.gameObject);
		}
	}

	private void handleObject(GameObject obj) {
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

	private void handleEnemy(GameObject enemyObj) {
//		Debug.Log ("FlashlightManager:handleEnemy: Enemy hit");
	}

	private void handleSurvivor(GameObject survivorObj) {
//		Debug.Log ("FlashlightManager:handleSurvivor: Survivor hit");
	}

	private void handleInteractiveObject(GameObject interactiveObj) {
//		Debug.Log ("FlashlightManager:handleInteractiveObject: Interactive object hit");

		switch (interactiveObj.name) {
			case "Building Elevator Go Up Button": {
				handleElevatorUpButton (interactiveObj);
				break;
			}
		}
	}

	private void handleElevatorUpButton(GameObject elevatorUpButton) {
		ElevatorFloorManager interactiveObjectManager = elevatorUpButton.GetComponent<ElevatorFloorManager> ();
		interactionTooltip.text = interactiveObjectManager.GetTooltip ();

		if (Input.GetMouseButtonDown(0)) {
			interactiveObjectManager.Interact();
		}
	}
}
