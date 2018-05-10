﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable {

	public Dialogue dialogue;

	public void DialogueLocation(){
		FindObjectOfType<DialogueManage> ().startDialogue (dialogue);
	}

	public override void Interact(){
		base.Interact ();

		DialogueLocation();
	}

}