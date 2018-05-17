using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerDoor : MonoBehaviour {

	public GameObject guiObject;
	public GameObject nope;

	public GameObject triggerKey;
	public GameObject doorTrigger;

	public GameObject quest2;
	public GameObject quest3;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);

	}

	/*void Update(){
		if(playerStats.bagAndKey == true){
			doorTrigger.SetActive (true);
			Debug.Log ("ajhaahhaha");
		}
	}*/



	// a fixer pour gere le retour dans la chambre sans les triggers et les pckable objects
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (playerStats.bagAndKey == false) {
				if(inventorySystem.invent.Contains("schoolBag")){
					guiObject.SetActive (true);
				}
				// if you don't have the key
				if (!inventorySystem.invent.Contains ("Key") && (inventorySystem.invent.Contains("schoolBag"))) {
					nope.SetActive (true);
					guiObject.SetActive (false);
					triggerKey.SetActive (true);

					quest2.SetActive (false);
					quest3.SetActive (true);
				}

			}
			if (playerStats.bagAndKey == true) {
				guiObject.SetActive (true);
				if(Input.GetButtonDown("Use")){
					FindObjectOfType<audioManager> ().Play ("doorOpen");
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
