using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControler : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
	characterCombat combat;

	bool isWalking = false;
	bool isAttackng = false;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		target = PlayerManager.instance.player.transform; 
		combat = GetComponent<characterCombat> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.position, transform.position);

		if(distance <= lookRadius){
			anim.SetBool ("isWalking", true);
			isWalking = true;
			agent.SetDestination (target.position);
			if (distance <= agent.stoppingDistance) {
				anim.SetBool ("isWalking", false);
				isWalking = false;
				characterStats targetStats = target.GetComponent<characterStats> ();
				if(targetStats != null){
					// Attack the target
					combat.Attack(targetStats);
				}

				// Face the target
				FaceTarget();
			}
			isAttackng = false;
		}

		// Handle the stop of the walking Animation when the skeleton stop.
		if (distance > 1.8 * lookRadius) {
			anim.SetBool ("isWalking", false);
			isWalking = false;

		}

		// Handle the Attack animaton of the Skeleton
		if(isWalking == true){
			anim.SetBool ("isAttacking", false);
			isAttackng = false;
		}
		if (isAttackng == true) {
			anim.SetBool ("isAttacking", true);
		}
	}

	void FaceTarget(){
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
