using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class gameControl : MonoBehaviour {

	public static gameControl control;

	public float cSharpKnowledge;
	public float unityKnowledge;
	public float threeDKnowledge;

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	// Test of data
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 100, 30), "C Shap : " + cSharpKnowledge);
	}
}
