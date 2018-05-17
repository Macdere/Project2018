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

	public void Start(){
	}

	public override void Interact(){
		base.Interact ();

		PickUp ();
	}

	void PickUp(){

		playerStats.instance.gainHealth();

		playerStats.instance.healthModification();

		playerStats.instance.updateHealthBar ();

		FindObjectOfType<audioManager> ().Play ("pickUpHeal");

		Destroy (gameObject);
		spawnHelp.count--;
		
	
	}
}
