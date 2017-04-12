using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Highlights objects when focused on by the player 
 */
public class MouseHighlight : MonoBehaviour {

	private void Start () {
		
	}

	private void Update () {
		
	}

	private void OnMouseEnter() {
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/ImageEffectShader");
	}

	private void OnMouseExit() {
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
	}
}
