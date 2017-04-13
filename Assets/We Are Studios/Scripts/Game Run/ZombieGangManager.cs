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
