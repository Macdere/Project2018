using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickAndMove : MonoBehaviour {
	[Header("Stats")]
	public float attackDistance;
	public float attackRate;
	private float nextAttack;
	const float k_Half = 0.5f;
	float m_ForwardAmount;

	private NavMeshAgent agent;
	private Animator m_Animator;

	private Transform targetedEnemy;
	private bool enemyClicked;
	private bool m_IsGrounded;
	// Use this for initialization
	void Awake () {
		m_Animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetButtonDown("Fire2")) {
			if(Physics.Raycast(ray, out hit, 1000)){
				if(hit.collider.tag == "Enemy"){
					targetedEnemy = hit.transform;
					enemyClicked = true;
				}
				else{
					m_IsGrounded = true;
					enemyClicked = false;
					agent.isStopped = false;
					agent.destination = hit.point;
				}
			}
		}
		if (enemyClicked){
			moveAndAttack ();	
		}
		if(agent.remainingDistance <= agent.stoppingDistance){
					m_IsGrounded = false;
		}
		else{
					m_IsGrounded = true;
		}
			
		m_Animator.SetBool("isWalking", m_IsGrounded);
	}
	void moveAndAttack(){
		if (targetedEnemy == null) {
			return;
		}

		agent.destination = targetedEnemy.position;

		if (agent.remainingDistance > attackDistance) {
			agent.isStopped = false;
			m_IsGrounded = true;
		} else {
			transform.LookAt (targetedEnemy);
			//Vector3 dirAttack = targetedEnemy.transform.position - transform.position;
				if(Time.time > nextAttack){
					nextAttack = Time.time + attackRate;
				}
			agent.isStopped = true;
			m_IsGrounded = false;
		}
	}
}
