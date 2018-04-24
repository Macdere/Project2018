using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	public LayerMask movementMask;
	Camera cam;
	public Interactable focus;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")){
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
		focus = newFocus;
	}

	void removeFocus(){
		focus = null;
	}
}
