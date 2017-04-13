using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 *	Script is attached to the Player First Person Camera Game Object 
 */
public class FlashlightManager : MonoBehaviour {
	public GameRunManager gameRunManager;
	public Light lightSource;


	public void ToggleFlashlight() {
		lightSource.enabled = !lightSource.enabled;
	}

	public void SetEnabled(bool enabled) {
		lightSource.enabled = enabled;
	}

	public void RotateToInitialRotation() {
		transform.rotation = initialRotation;
	}

	private const float DISTANCE_TO_SEE = 30;
	private Quaternion initialRotation;


	private void Start () {
		initialRotation = transform.rotation;
	}

	private void Update () {
		Focus ();
	}

	private void Focus() {
		Debug.DrawRay (this.transform.position, 
			this.transform.forward * DISTANCE_TO_SEE, Color.magenta);

		RaycastHit focusedObject;
		if (Physics.Raycast (this.transform.position, 
			this.transform.forward, out focusedObject, DISTANCE_TO_SEE)) {
			gameRunManager.NotifyGameObjectSeen (focusedObject.collider.gameObject);
		}
	}
}
