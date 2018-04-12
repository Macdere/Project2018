﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor : MonoBehaviour {

	public GameObject guiObject;
	public GameObject nope;

	public GameObject triggerKey;

	public GameObject quest2;
	public GameObject quest3;

	public string sceneName;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			// if character.inventory don't contains the 2 items bag and keys then:

			nope.SetActive(true);

			triggerKey.SetActive(true);

			quest2.SetActive(false);
			quest3.SetActive(true);
			//else if character.inventory contains the 2 items then: allow th player to open the door with e to a new scene
		}
	}
	void OnTriggerExit(){
		guiObject.SetActive(false);
		nope.SetActive(false);
	}
}