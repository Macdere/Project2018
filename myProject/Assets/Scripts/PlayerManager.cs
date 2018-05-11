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

	public GameObject Camp1;
	public GameObject Camp2;
	public GameObject Camp3;
	public GameObject Camp4;

	public bool Save1 = false;
	public bool Save2 = false;
	public bool Save3 = false;
	public bool Save4 = false;

	// If the player get killed, the scene he is in will restart at the beginning.
	public void playerKilled(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void gameStatus(){
		if(Camp1 == null){
			Save1 = true;
		}
		if(Camp2 == null){
			Save2 = true;
		}
		if(Camp3 == null){
			Save3 = true;
		}
		if(Camp4 == null){
			Save4 = true;
		}
	}

}
