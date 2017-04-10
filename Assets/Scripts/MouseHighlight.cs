using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHighlight : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseEnter() {
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/ImageEffectShader");
	}

	void OnMouseExit() {
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
	}
}
