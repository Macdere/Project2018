using UnityEngine;


public class characterStats : MonoBehaviour {

	public static characterStats instance;

	public int maxHealth = 100;

	public int currentHealth{ get; set;}

	public Stat damage;
	public Stat health;

	public event System.Action<int,int> OnHealthChanged;

	void Awake(){

		instance = this;
		currentHealth = maxHealth;
	}


	public void DamageTaken(int someDamage){
		currentHealth -= someDamage;
		Debug.Log (transform.name + " takes " + someDamage + " damage.");

		//To update the healthbar
		if (OnHealthChanged != null) {
			OnHealthChanged (maxHealth, currentHealth);
		}

		// if health reach zero
		if (currentHealth <= 0) {
			Die ();
		}
	}

	public virtual void Die(){

		// This method must be overwritten

		Debug.Log (transform.name + " died.");
	}

}
