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

	public delegate void OnBonusChanged();
	public OnBonusChanged onBonusChanged;

	public override void Interact(){
		base.Interact ();

		PickUp ();
	}

	void PickUp(){

		if(onBonusChanged != null){
			onBonusChanged.Invoke ();
		}

		Destroy (gameObject);
		spawnHelp.count--;
	
	}
}
