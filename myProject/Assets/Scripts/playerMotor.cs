using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class playerMotor : MonoBehaviour {

	NavMeshAgent agent;
	Transform target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update(){
		if (target != null) {
			agent.SetDestination (transform.position);
		}
	}

	public void FollowTarget(Interactable newTarget){
		target = newTarget.transform;
	}

	public void stopFollowTarget(){
		target = null;
	}


}
