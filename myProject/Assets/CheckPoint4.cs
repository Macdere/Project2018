using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint4 : MonoBehaviour {

	public GameObject EnemyOne;
	public GameObject EnemyTwo;
	public GameObject item;

	// Update is called once per frame
	void Update () {
		if (PlayerManager.instance.Save4) {
			if (EnemyOne != null && EnemyTwo != null && item != null) {
				EnemyOne.SetActive (false);
				EnemyTwo.SetActive (false);
				item.SetActive (false);
			}
		} else {
			if (EnemyOne != null && EnemyTwo != null && item != null) {
				EnemyOne.SetActive (true);
				EnemyTwo.SetActive (true);
				item.SetActive (true);
			}
		}
	}
}
