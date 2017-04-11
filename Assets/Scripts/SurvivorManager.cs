using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Controls the survivor's action, spawning, etc.
 * The script is attached to the survivor object.
 */
public class SurvivorManager : RunningNPC {

	private void Start() {
		base.Start ();
		base.SetMoveSpeed (3.0f);
	}

	private void Update() {
		base.Update ();
	}

}
