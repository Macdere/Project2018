using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour {

	public GameObject EnemyOne;
	public GameObject EnemyTwo;
	public GameObject item;

	// Update is called once per frame
	void Update () {
		if (PlayerManager.instance.Save1) {

			EnemyOne.SetActive (false);
			EnemyTwo.SetActive (false);
			item.SetActive (false);
		} else {
			EnemyOne.SetActive (true);
			EnemyTwo.SetActive (true);
			item.SetActive (true);
		}
	}
}
