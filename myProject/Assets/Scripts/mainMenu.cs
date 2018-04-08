using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadGame(){
		Debug.Log ("Load your Game");
	}

	public void QuitGame(){

		Debug.Log ("You Quit the Game");
		Application.Quit ();
	}
}
