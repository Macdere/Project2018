using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questStatus : MonoBehaviour {

	public GameObject questUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats.bagAndKey == true) {
			questUI.SetActive (false);
		}
	}
}
