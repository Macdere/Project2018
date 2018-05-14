using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

	public Color startColor;

	bool mouseOver = false;
	// Use this for initialization
	void OnMouseEnter () {
		mouseOver = true;
		GetComponentInChildren<Renderer> ().material.color = Color.green;
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		mouseOver = false;
		GetComponentInChildren<Renderer> ().material.color = startColor;
	}

	// Don't work I don'tknow why
}
