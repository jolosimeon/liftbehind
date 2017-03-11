using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManagerScript : MonoBehaviour {

    private static BGMManagerScript _instance;
    private static AudioSource source;

    public static BGMManagerScript instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BGMManagerScript>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        StartMusic();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void StartMusic() { source.Play(); }

    public static void StopMusic() { source.Stop(); }
}
