using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour {

	public bool endOfGame;
	public string endScene;

	GameObject Boss;

	// Use this for initialization
	void Start () {
		endOfGame = false;
		Boss = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Boss == null) {
			endOfGame = true;

			// Launch Animation of end of game.
			SceneManager.LoadScene(endScene);

		}
	}
}
