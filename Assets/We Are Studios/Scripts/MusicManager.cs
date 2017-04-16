using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music Player");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Gameplay") {
            Destroy(this.gameObject);
        }
    }
}
