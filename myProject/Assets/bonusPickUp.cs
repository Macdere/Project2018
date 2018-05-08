using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusPickUp : Interactable{

	#region Singleton
	public static bonusPickUp instance;
	void Awake(){
		instance = this;
	}
	#endregion

	public int bonusHealth = 25;


	public override void Interact(){
		base.Interact ();

		PickUp ();
	}

	void PickUp(){

		playerStats.instance.gainHealth();
		Destroy (gameObject);
		spawnHelp.count--;
	
	}
}
