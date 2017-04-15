using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private AudioSource audio;
	private Vector3 moveVector;
	private float speed =0.5f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;
	public Text lives;
	public int maxLife = 5;
	public int points = 0;
	public AudioClip[] audioClip;
	// Use this for initialization
	public GameObject player;
	public int flag = -1;
	void Start () {
		
		controller = GetComponent<CharacterController> ();
		audio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//lives.text = "BAKLA";
		moveVector = Vector3.zero;
		if(controller.isGrounded)
			{
				verticalVelocity = -0.5f;
			}
		else
			{
			verticalVelocity -= gravity * Time.deltaTime;
			}
		moveVector.x = flag * speed;
		moveVector.y = verticalVelocity;
		moveVector.z = Input.GetAxisRaw ("Horizontal") * speed;
		controller.Move (moveVector * Time.deltaTime);
		if (player.transform.position.x < -22)
			flag = 1;
			
		if (player.transform.position.x > 3 )
			flag = -1;

	}

	void OnControllerColliderHit (ControllerColliderHit collision)
	{
		if (collision.gameObject.tag == "Barrier") 
		{
				maxLife -= 1;
		
			lives.text = "Lives left: " + maxLife + "\nCoins: " + points;
			//audio.Play ();
			Destroy (collision.gameObject);
			print ("HAHA");
			if (maxLife == 0) {
				lives.text = "GAME OVER";
				//controller.gameObject.SetActive (false);
				//controller.gameObject.SetActive (true);
				//maxLife = 5;
				//lives.text = "Lives left: " + maxLife + " \n Coins: " + points;

					Application.LoadLevel (Application.loadedLevel);
				
			}
			PlaySound (1);

		}

		if (collision.gameObject.tag == "Coin") 
		{
			points += 1;
			Destroy (collision.gameObject);
			PlaySound (0);
			if (points > 10) {
				if(speed <= 45)
					speed = speed + 0.5f;
			}
			lives.text = "Lives left: " + maxLife + "\nCoins: " + points;
			if (points%50 == 0) {


				lives.text = "Lives left: " + maxLife +" + 1"+ "\nCoins: " + points;
				maxLife = maxLife + 1;
				//lives.text = "Lives left: " + maxLife + "\nCoins: " + points;
				PlaySound (2);
			}

				
		}

	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource> ().clip = audioClip [clip];
		GetComponent<AudioSource> ().Play ();
	}
}
