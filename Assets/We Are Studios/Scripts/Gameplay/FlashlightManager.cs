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
    private AudioSource flashlightAudio;
    public AudioSource flashlightAmbient;

	public void ToggleFlashlight() {
		lightSource.enabled = !lightSource.enabled;
        flashlightAudio.PlayOneShot(flashlightAudio.clip);
	}

	public void SetEnabled(bool enabled) {
        lightSource.enabled = enabled;
        flashlightAudio.PlayOneShot(flashlightAudio.clip);
        if (lightSource.enabled)
            flashlightAmbient.Play();
        else {
            flashlightAmbient.Stop();
        }
    }

	public void RotateToInitialRotation() {
		transform.rotation = initialRotation;
	}

	private const float DISTANCE_TO_SEE = 30;
	private Quaternion initialRotation;


	private void Start () {
		initialRotation = transform.rotation;
        flashlightAudio = gameObject.GetComponent<AudioSource>();
        //flashlightAmbient.Play();
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
