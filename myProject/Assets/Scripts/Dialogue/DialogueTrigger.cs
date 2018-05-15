using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable {

	public Dialogue dialogue;

	public GameObject helloOne;
	public GameObject helloTwo;

	public void DialogueLocation(){
		FindObjectOfType<DialogueManage> ().startDialogue (dialogue);
	}

	public void End(){
		FindObjectOfType<DialogueManage> ().endDialogue ();
	}

	public override void Interact(){
		base.Interact ();

		DialogueLocation ();

		helloOne.SetActive (false);
		helloTwo.SetActive (false);

	}

	/*public void Update(){
		float distance = Vector3.Distance (player.position, gameObject.transform.position);
		Debug.Log (radius);

		if (distance > radius) {
			End ();
		}
	}*/

}
