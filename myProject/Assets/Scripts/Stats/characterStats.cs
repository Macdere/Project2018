using UnityEngine;

public class characterStats : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth{ get; set;}

	public Stat damage;
	public Stat health;

	void Awake(){
		currentHealth = maxHealth;
	}


	public void DamageTaken(int someDamage){
		currentHealth -= someDamage;
		Debug.Log (transform.name + " takes " + someDamage + " damage.");

		if (currentHealth <= 0) {
			Die ();
		}
	}

	public virtual void Die(){

		// This method must be overwritten

		Debug.Log (transform.name + " died.");
	}

}
