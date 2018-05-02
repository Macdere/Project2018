using UnityEngine;

public class characterStats : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth{ get; private set;}

	public Stat damage;

	void Awake(){
		currentHealth = maxHealth;
	}

	// Simulation of Taking damage
	void Update(){
		if (Input.GetKeyDown (KeyCode.T)) {
			DamageTaken (10);
		}

	}

	public void DamageTaken(int damage){
		currentHealth -= damage;
		Debug.Log (transform.name + " takes " + damage + " damage.");

		if (currentHealth <= 0) {
			Die ();
		}
	}

	public virtual void Die(){

		// This method must be overwritten

		Debug.Log (transform.name + " died.");
	}

}
