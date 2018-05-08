using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : characterStats {
	
	public static bool bagAndKey;

	// Use this for initialization
	void Start () {

		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
		bonusPickUp.instance.onBonusChanged += OnBonusChanged;


		// Need to keep the condition if the player don't restart a new game so he will already have picked up the items
		if(inventorySystem.invent.Contains("schoolBag") && (inventorySystem.invent.Contains("Key"))){
			bagAndKey = true;
		}else{
			bagAndKey = false;
		}
	}

	void Update(){
		if (inventorySystem.invent.Contains ("schoolBag") && (inventorySystem.invent.Contains ("Key"))) {
			bagAndKey = true;
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			DamageTaken(10);
		}
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem){
		if(newItem != null){
			health.addModifier (newItem.healthModifier);
			maxHealth += newItem.healthModifier;
			currentHealth += newItem.healthModifier;
			damage.addModifier (newItem.damageModifier);
		}

		if(oldItem != null){
			health.removeModifier (oldItem.healthModifier);
			maxHealth -= oldItem.healthModifier;
			currentHealth -= oldItem.healthModifier;
			damage.removeModifier (oldItem.damageModifier);
		}
	}

	void OnBonusChanged(){
		if (currentHealth + bonusPickUp.instance.bonusHealth < maxHealth) {
			currentHealth += bonusPickUp.instance.bonusHealth;
		} else {
			currentHealth += (maxHealth - currentHealth);
		}
	}

	public override void Die(){
		base.Die ();
		//Kill the player. I will maybe restart the scen if the player died
		PlayerManager.instance.playerKilled();
	}

}
