using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour {


	private void Start () {
		
	}

	private void Update () {
		
	}

	public void StartGame() {
		SceneManager.LoadScene ("Game Difficulty");
	}

	public void Instructions() {

	}
}
