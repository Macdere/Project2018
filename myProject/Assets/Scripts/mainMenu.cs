using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	public string levelToLoad;

	public void PlayGame(){
		SceneManager.LoadScene(levelToLoad);
	}

	public void LoadGame(){
		Debug.Log ("Load your Game");
	}

	public void QuitGame(){

		Debug.Log ("You Quit the Game");
		Application.Quit ();
	}
}
