using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour {


	private void Start () {
		
	}

	private void Update () {
		
	}
    
    IEnumerator buttonLoad(string scene) {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(scene);
    }

	public void StartGame() {
        StartCoroutine(buttonLoad("Game Difficulty"));
	}

	public void Instructions() {
        StartCoroutine(buttonLoad("Instructions"));
	}
}
