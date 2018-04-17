using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerDoor : MonoBehaviour {

	public GameObject guiObject;
	public GameObject nope;

	public GameObject triggerKey;

	public inventorySystem inventory;

	public GameObject quest2;
	public GameObject quest3;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (inventory.inventory.GetValue(1)){
				nope.SetActive (true);

				triggerKey.SetActive (true);

				quest2.SetActive (false);
				quest3.SetActive (true);
			
				//else if character.inventory contains the 2 items then: allow th player to open the door with e to a new scene
				if ((System.Array.IndexOf(inventory.inventory,"schoolBag") != -1) && (System.Array.IndexOf(inventory.inventory,"Key") != -1)) {
					SceneManager.LoadScene (levelToLoad);
				}
			}
		}
	}
	void OnTriggerExit(){
		guiObject.SetActive(false);
		nope.SetActive(false);
	}
}
