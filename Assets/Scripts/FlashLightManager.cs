using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour {
	private AudioClip soundTurnOn;
	private AudioClip soundTurnOff;
	public Light lightSource;

	void Start () {

	}

	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			Toggle ();
		}
	}

	void Toggle() {
		lightSource.enabled = !lightSource.enabled;

		if (lightSource.enabled) {
			GetComponent<AudioSource> ().clip = soundTurnOn;
		} else {
			GetComponent<AudioSource> ().clip = soundTurnOff;
		}
	}
}
