using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the zombie's action, spawning, etc.
 * The script is attached to the zombie object.
 */
public class ZombieManager : RunningNPC {

	private void Start() {
		base.Start ();
		base.SetMoveSpeed (1.5f);
	}

	private void Update() {
		base.Update ();
	}

	public void DoJumpScare () {
		Debug.Log ("ZombieManager:DoJumpScare: Doing jump scare");
	}
}
