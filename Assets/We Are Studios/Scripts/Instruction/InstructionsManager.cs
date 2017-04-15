using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}

	public void BackToMenu() {
		SceneManager.LoadScene ("Game Menu");
	}
}
