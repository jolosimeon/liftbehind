using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	public AudioClip[] audioClip;
	// Use this for initialization
	void Start () {

		PlaySound (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip [clip];
		GetComponent<AudioSource> ().Play ();

	}
}
