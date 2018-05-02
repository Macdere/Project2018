using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;

	void Awake(){
		instance = this;
	}

	#endregion

	public GameObject player;

	// If the player get killed, the scene he is in will restart at the beginning.
	public void playerKilled(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
