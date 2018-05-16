using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour {

	public string nameScene;

	public void Next(){
		SceneManager.LoadScene (nameScene);
	}
}
