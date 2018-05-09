using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))]
public class Enemy : Interactable {

	PlayerManager playerManager;
	characterStats myStats;

	void Start(){
		playerManager = PlayerManager.instance;
		myStats = GetComponent<characterStats> ();
	}

	public override void Interact(){

		base.Interact ();
		characterCombat playerCombat = playerManager.player.GetComponent<characterCombat> ();
		if(playerCombat != null){
			playerCombat.Attack (myStats);
		}
	}

}
