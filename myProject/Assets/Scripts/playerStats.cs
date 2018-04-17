using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
	
	public static bool bagAndKey;

	// Use this for initialization
	void Start () {
		if(inventorySystem.inventory.Contains("schoolBag") && (inventorySystem.inventory.Contains("Key"))){
			bagAndKey = true;
		}else{
			bagAndKey = false;
		}
	}

}
