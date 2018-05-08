using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusPickUp : Interactable{

	public int bonusHealth = 25;

	public override void Interact(){
		base.Interact ();

		PickUp ();
	}

	void PickUp(){

		Debug.Log ("Gain "+ bonusHealth +" Health");

		characterStats.currentHealth += bonusHealth;
		Destroy (gameObject);
		spawnHelp.count--;
	
	}
}
