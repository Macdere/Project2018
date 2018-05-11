using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : characterStats {

	// If we have problems later maybe because of this instantiation
	#region Singleton
	public static playerStats instance;
	void Awake(){
		instance = this;
	}
	#endregion


	healthUI myUI;

	public static bool bagAndKey;
	private float delay = 1 ;

	// Use this for initialization
	void Start () {

		myUI = GetComponent<healthUI> ();

		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
		currentHealth = 100;

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

		if ((Input.GetKey(KeyCode.H)) && (currentHealth < maxHealth)){
			if (delay < 0){
				currentHealth += 2;
				// Adapt the healthBarUI Need to adapt because bug of full life
				healthModification();
				delay = 1;
			}
		}
		if(delay > -1){
			delay -= Time.deltaTime;
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

	public void gainHealth(){
		if (currentHealth + bonusPickUp.instance.bonusHealth < maxHealth) {
			currentHealth += bonusPickUp.instance.bonusHealth;
		} else {
			currentHealth += (maxHealth - currentHealth);
		}

	}

	public void healthModification(){
		if (myUI.ui != null) {
			myUI.ui.gameObject.SetActive (true);
			myUI.lastVisibleTime = Time.time;

			float healthPercent = (float)currentHealth / maxHealth;
			myUI.healthSlider.fillAmount = healthPercent;


			if (currentHealth <= 0) {
				Destroy (myUI.ui.gameObject);
			}
		}
	}

	public int GetCurrentHealth(){
		return currentHealth;
	}

	public void setCurrentHealth(int Health){
		currentHealth = Health;
	}

	public override void Die(){
		base.Die ();
		//Kill the player. I will maybe restart the scen if the player died
		PlayerManager.instance.playerKilled();
	}

}
