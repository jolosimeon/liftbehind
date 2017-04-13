using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


/**
 *	Script is attached to the Game Over Manager Game Object 
 */
public class GameOverManager : MonoBehaviour {
	public const int CAUSE_ZOMBIE_IN_ELEVATOR = 0;

	public GameObject zombieInElevator;

	private void Start() {
//		DeactivateAll ();

		int gameOverCause = 0;
		switch (gameOverCause) {
			case CAUSE_ZOMBIE_IN_ELEVATOR:{
				zombieInElevator.SetActive (false);
				break;
			}
		}
	}

	private void DeactivateAll() {
		zombieInElevator.SetActive (false);
	}

	private void Update() {

	}
}
