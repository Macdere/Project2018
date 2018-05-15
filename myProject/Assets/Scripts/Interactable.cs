using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;
	bool hasInteracted = false;

	Transform player;


	public virtual void Interact(){
		// This is meant to be overWritten
		//Debug.Log("Interacting");
	}

	void Update() {
		if (isFocus && !hasInteracted) {
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			if (distance <= radius) {
				Interact ();
				hasInteracted = true;
			} 
		}
	}

	public void OnFocused(Transform playerTransform){
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
		faceTarget (transform); // Need to see why it's not working
	}

	public void OnDefocused(){
		isFocus = false;
		player = null; 
		hasInteracted = false;
	}

	void OnDrawGizmosSelected(){
		if(interactionTransform == null){
			interactionTransform = transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position,radius);
	}

	void faceTarget(Transform ourObject){
		transform.LookAt (ourObject);
	}
}
