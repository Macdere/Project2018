using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObject : MonoBehaviour {

	public GameObject guiObject;
	public GameObject pickableObject;
	public GameObject triggerBag;
	public GameObject triggerDoor;


	public GameObject quest1;
	public GameObject quest2;


	// Use this for initialization
	void Start () {
		guiObject.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {
			guiObject.SetActive(true);
			if(guiObject.activeInHierarchy == true && Input.GetButtonDown("Use")){
				pickableObject.SetActive(false);

				triggerBag.SetActive(false);
				triggerDoor.SetActive(true);

				guiObject.SetActive(false);

				inventorySystem.inventory.Add ("schoolBag");

				quest1.SetActive(false);
				quest2.SetActive(true);
			}
		}
	}
	void OnTriggerExit(){
		guiObject.SetActive(false);
	}
}
