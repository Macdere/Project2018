using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : Interactable {

	public Items item;

	public override void Interact(){
		base.Interact ();

		PickUp ();
	}

	void PickUp(){

		Debug.Log ("Picking up " + item.name);
		bool pickedUp = inventorySystem.instance.Additem (item);
		if (pickedUp) {
			Destroy (gameObject);
		}
	}
}
