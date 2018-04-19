using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
	
	public static bool bagAndKey;

	// Use this for initialization
	void Start () {
		// Need to keep the condition if the player don't restart a new game so he will already have picked up the items
		if(inventorySystem.inventory.Contains("schoolBag") && (inventorySystem.inventory.Contains("Key"))){
			bagAndKey = true;
		}else{
			bagAndKey = false;
		}
	}

	void Update(){
		if (inventorySystem.inventory.Contains ("schoolBag") && (inventorySystem.inventory.Contains ("Key"))) {
			bagAndKey = true;
		}
	}

}
