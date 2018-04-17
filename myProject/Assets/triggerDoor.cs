using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerDoor : MonoBehaviour {

	public GameObject guiObject;
	public GameObject nope;

	public GameObject triggerKey;

	public GameObject quest2;
	public GameObject quest3;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive(true);
			// if you don't have the key
			if(!inventorySystem.inventory.Contains("Key")){
				nope.SetActive (true);
				guiObject.SetActive(false);
				triggerKey.SetActive (true);

				quest2.SetActive (false);
				quest3.SetActive (true);
			}
				//else if character.inventory contains the 2 items then: allow th player to open the door with e to a new scene
			if (inventorySystem.inventory.Contains("Key") && Input.GetButtonDown("Use")) {
					SceneManager.LoadScene (levelToLoad);
			}
		}
	}
	void OnTriggerExit(){
		guiObject.SetActive(false);
		nope.SetActive(false);
	}
}
