using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGangManager : MonoBehaviour {
	public GameObject zombie1;
	public GameObject zombie2;
	public GameObject zombie3;

	private Animator animator1;
	private Animator animator2;
	private Animator animator3;

	private KeyCode[] possibleKeys = {
		KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G,
		KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N,
		KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U,
		KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z,

		KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5,
		KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
	};

	public void SetActive(bool active) {
		zombie1.SetActive (active);
		zombie2.SetActive (active);
		zombie3.SetActive (active);
	}

	void Start () {
		
	}

	void Update () {
		
	}
}
