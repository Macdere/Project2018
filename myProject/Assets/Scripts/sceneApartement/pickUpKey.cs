using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpKey : MonoBehaviour {

	public GameObject guiObject;
	public GameObject pickableObject;
	public GameObject triggerKey;

	public GameObject quest3;
	public GameObject quest4;

	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive(true);
			if(guiObject.activeInHierarchy == true && Input.GetButtonDown("Use")){
				pickableObject.SetActive(false);

				triggerKey.SetActive(false);

				guiObject.SetActive(false);

				inventorySystem.invent.Add ("Key");

				quest3.SetActive(false);
			}
		}
	}
	void OnTriggerExit(){
		guiObject.SetActive(false);
	}
}
