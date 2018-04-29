using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;

	bool isFocus = false;
	bool hasInteracted = false;

	Transform player;

	public virtual void Interact(){
		// This is meant to be overWritten
		Debug.Log("Interacting");
	}

	void Update() {
		if(isFocus && !hasInteracted){
			float distance = Vector3.Distance (player.position, transform.position);
			if(distance <= radius){
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
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position,radius);
	}

	void faceTarget(Transform ourObject){
		transform.LookAt (ourObject);
	}
}
