using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : characterStats {

	public override void Die(){
		base.Die ();
		// Add some animations or some for the death of the enemy

		Destroy(gameObject);
	}

}
