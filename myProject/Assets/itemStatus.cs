using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemStatus : MonoBehaviour {

	public GameObject pickableObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats.bagAndKey == true) {
			pickableObjects.SetActive (false);
		}
	}
}
