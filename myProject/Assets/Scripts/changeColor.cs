using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {

	public Color startColor;
	public Color newColor;
	public float duration = 1.0F;
	Renderer rend;

	bool mouseOver = false;

	public void Start(){
		rend = GetComponent<Renderer> ();
	}
	// Use this for initialization
	void OnMouseEnter () {
		mouseOver = true;
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		rend.material.color = Color.Lerp(startColor, newColor, lerp);
	}
	
	// Update is called once per frame
	void OnMouseExit () {
		mouseOver = false;
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		rend.material.color = Color.Lerp(newColor, startColor, lerp);
	}

	// Don't work I don'tknow why
}
