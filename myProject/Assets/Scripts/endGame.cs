using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour {

	#region Singleton
	public static endGame instance;
	void Awake(){
		instance = this;
	}
	#endregion

	public bool endOfGame;
	public string endScene;

	public GameObject Boss;

	// Use this for initialization
	void Start () {
		endOfGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Boss == null) {
			endOfGame = true;
		}
		if (endOfGame) {
			SceneManager.LoadScene (endScene);
		}
	}
}
