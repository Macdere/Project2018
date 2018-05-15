using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameDialogue : MonoBehaviour {

	bool finGame;
	public GameObject endGameUI;
	public GameObject triggerDoor;

	public void Start(){
		if (endGame.instance.endOfGame != null) {
			finGame = endGame.instance.endOfGame;
		}
	}

	// Update is called once per frame
	void Update () {
		if (finGame) {
			endGameUI.SetActive (true);
			triggerDoor.SetActive (false);
		}
	}
}
