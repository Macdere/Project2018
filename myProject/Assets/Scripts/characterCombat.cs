using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))]
public class characterCombat : MonoBehaviour {

	characterStats myStats;

	public float attackDelay = .6f;
	//public float attackSpeed = 1f;
	private float attackCooldown = 0f;

	private Animator anim;

	// Call Back method to know when we are attacking
	public event System.Action OnAttack;

	void Start(){
		anim = GetComponent<Animator> ();
		myStats = GetComponent<characterStats> ();
	}

	void Update(){
		attackCooldown -= Time.deltaTime;
	}

	public void Attack(characterStats targetStats){

		if(attackCooldown <= 0f){

			StartCoroutine (DoDamage (targetStats, attackDelay));
			if (gameObject.tag == "Player") {
				FindObjectOfType<audioManager>().Play ("attackSword");
			} else {
				StartCoroutine (playSoundAfterSomeSec ());
			}
			if (OnAttack != null) {
				OnAttack ();
			}

			attackCooldown = 1.2f;
		}
	}


	// Add delay to allow the animation to play for example wiating the sword to fall on the enemy
	// before actually do the damage
	IEnumerator DoDamage (characterStats stats, float delay){
		
		yield return new WaitForSeconds (delay);

		anim.SetBool ("isAttacking", true);
		stats.DamageTaken (myStats.damage.GetValue ());
	}

	IEnumerator playSoundAfterSomeSec (){

		yield return new WaitForSeconds (1.5f);
		FindObjectOfType<audioManager>().Play ("attackSword");

	}

}
