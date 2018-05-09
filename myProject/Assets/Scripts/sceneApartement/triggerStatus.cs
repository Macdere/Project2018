using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerStatus : MonoBehaviour {

	public GameObject triggers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats.bagAndKey == true) {
			triggers.SetActive (false);
		}
	}
}
