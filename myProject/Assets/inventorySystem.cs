using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour {

	public static List<string> inventory = new List<string>();

	public static List<string> getList(){
			return inventory;
		
	}

	public static void Add(string tag){
		inventory.Add(tag);
	}


}
