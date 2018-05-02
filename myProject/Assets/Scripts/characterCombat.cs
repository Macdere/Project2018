﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))]
public class characterCombat : MonoBehaviour {

	characterStats myStats;

	public float attackDelay = .6f;
	public float attackSpeed = 1f;
	private float attackCooldown = 0f;

	// Call Back method to know when we are attacking
	public event System.Action OnAttack;

	void Start(){
		myStats = GetComponent<characterStats> ();
	}

	void Update(){
		attackCooldown -= Time.deltaTime;
	}

	public void Attack(characterStats targetStats){

		if(attackCooldown <= 0f){
			
			StartCoroutine (DoDamage (targetStats, attackDelay));

			if (OnAttack != null) {
				OnAttack ();
			}

			attackCooldown = 1f / attackSpeed;
		}
	}


	// Add delay to allow the animation to play for example wiating the sword to fall on the enemy
	// before actually do the damage
	IEnumerator DoDamage (characterStats stats, float delay){
		yield return new WaitForSeconds (delay);

		stats.DamageTaken (myStats.damage.GetValue ());
	}

}