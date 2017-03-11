using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		Debug.Log ("AHAW");
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Custom/ImageEffectShader");
	}
	void OnMouseExit()
	{
		gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
	}

}
