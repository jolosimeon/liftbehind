using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonMashManager : MonoBehaviour {
	public GameOverManager gameOverManager;

	private float timeAllowed;
	private float timeLeft;

	public int numberOfMashesRequired;
	public int numberOfMashesDone;

	private bool ongoing;

	void Start () {
		timeAllowed = 10.0f;
		numberOfMashesRequired = 20;
		ongoing = false;
	}

	void Update () {
//		if (!ongoing && Input.GetKeyDown (KeyCode.LeftShift)) { // Temporary Trigger
//			StartMash ();
//		}
//
//		if (ongoing) {
//			timeLeft -= Time.deltaTime;
//
//			if (timeLeft <= 0 && numberOfMashesDone < numberOfMashesRequired) {
//				gameOverManager.SendMessage ("PlayerLoss");
//				ongoing = false;
//			} else if (timeLeft <= 0 && numberOfMashesDone >= numberOfMashesRequired) {
//				statsManager.SendMessage ("AddSurvivor");
//				ongoing = false;
//			} else if (timeLeft > 0 && Input.GetKeyDown (KeyCode.B)) {
//				numberOfMashesDone++;
//			}
//		} 
	}

	void StartMash() {
		timeLeft = timeAllowed;
		numberOfMashesDone = 0;
		ongoing = true;
	}
}
