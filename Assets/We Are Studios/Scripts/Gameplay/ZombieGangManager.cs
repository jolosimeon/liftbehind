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

    public AudioSource[] zombiesAudio;
    public AudioClip[] sounds;
    public AudioClip damage;
    public AudioClip dead;
    public float frequencyMin = 4.0f;
    public float frequencyMax = 7.0f;
    private float timeLeft;
    private bool death = false;

    public GameRunManager gameRunManager;
	private int numKeysToDefeat;
	private int numKeysCorrect;


	private KeyCode[] possibleKeys = {
		KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G,
		KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N,
		KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U,
		KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z,
	};

	private KeyCode keyToPress;

	public void SetActive(bool active) {
		zombie1.SetActive (active);
		zombie2.SetActive (active);
		zombie3.SetActive (active);
	}

	public void AttackedByPlayer(KeyCode keyPressed) {
		if (keyPressed == keyToPress) {
			++numKeysCorrect;

			if (numKeysCorrect == numKeysToDefeat) {
				keyToPress = KeyCode.None;
                allPlay(dead);
                death = true;
                DefeatedByPlayer ();
            } else {
				keyToPress = GetRandomKeyCode ();
			}
		}
	}

	public KeyCode GetKeyToPress() {
		return keyToPress;
	}

	private void DefeatedByPlayer() {
		gameRunManager.NotifyZombieGangDefeated ();
		animator1.SetTrigger ("Defeat");
		animator2.SetTrigger ("Defeat");
		animator3.SetTrigger ("Defeat");
	}

	private void Start () {
		animator1 = zombie1.GetComponent<Animator> ();
		animator2 = zombie2.GetComponent<Animator> ();
		animator3 = zombie3.GetComponent<Animator> ();
        timeLeft = frequencyMin;
        allPlayRandom();
        Reset ();
	}

	private KeyCode GetRandomKeyCode() {
		int random = Random.Range (0, possibleKeys.Length);
		return possibleKeys [random];
	}

	private void Update () {
        if (!death) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) {
                allPlayRandom();
                timeLeft = Random.Range(frequencyMin, frequencyMax);
            }
        }
    }

	public void Reset() {
		animator1.Play ("attack");
		animator2.Play ("attack");
		animator3.Play ("attack");

		animator1.Rebind ();
		animator2.Rebind ();
		animator3.Rebind ();

		numKeysCorrect = 0;
		keyToPress = GetRandomKeyCode ();
	}

	public float GetHealthRatio() {
		float health = 1.0f - ((float)numKeysCorrect / (float)numKeysToDefeat);
		Debug.Log ("Zombie Gang Health: " + health);
		return health;
	}

	public void SetHealth(int health) {
		numKeysToDefeat = health;
	}

    public void allPlay(AudioClip clip) {
        for (int i = 0; i < zombiesAudio.Length; i++) {
            zombiesAudio[i].PlayOneShot(clip);
        }
    }

    public void allPlayRandom() {
        for (int i = 0; i < zombiesAudio.Length; i++) {
            int selected = Random.Range(0, 5);
            zombiesAudio[i].PlayOneShot(sounds[selected]);
        }
    }
}
