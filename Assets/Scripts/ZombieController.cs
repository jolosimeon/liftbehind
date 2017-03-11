using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// pasok dito pag may tumama
	void OnCollisionEnter(Collision col){
		Debug.Log ("ABA SER MA TUMAMA SAKIN ZOMBI AKO");
	}
		
	public void Startle() {
		Debug.Log ("aray ko ser sabi ni zombie");
		//Destroy (this.gameObject);
	}
}
