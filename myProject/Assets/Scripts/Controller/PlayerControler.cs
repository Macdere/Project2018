using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	playerMotor motor;

	Camera cam;
	public Interactable focus;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		//if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")){
		if(Input.GetButtonDown("deFocus")){
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if(Physics.Raycast(ray,out hit)){
				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable == null) {
					removeFocus ();
				}
			}
		}

		if(Input.GetMouseButtonDown(1)){
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit)){
				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable != null) {
					setFocus (interactable);
				}
			}
		}
	}

	void setFocus(Interactable newFocus){

		if(newFocus != focus){
			if (focus != null)
				focus.OnDefocused ();
			
		focus = newFocus;
		//motor.FollowTarget (focus);
		}
		newFocus.OnFocused (transform);
	}

	void removeFocus(){

		if (focus != null) {
			focus.OnDefocused ();
		}

		focus = null;
		//motor.stopFollowTarget ();
	}
}
