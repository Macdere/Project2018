﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint4 : MonoBehaviour {

	public GameObject EnemyOne;
	public GameObject EnemyTwo;
	public GameObject EnemyThree;
	public GameObject item;

	// Update is called once per frame
	void Update () {
		if (PlayerManager.instance.Save4) {
			if (EnemyOne != null && EnemyTwo != null && EnemyThree != null && item != null) {
				EnemyOne.SetActive (false);
				EnemyTwo.SetActive (false);
				EnemyThree.SetActive (false);
				item.SetActive (false);
			}
		} else {
			if (EnemyOne != null && EnemyTwo != null && EnemyThree != null && item != null) {
				EnemyOne.SetActive (true);
				EnemyTwo.SetActive (true);
				EnemyThree.SetActive (false);
				item.SetActive (true);
			}
		}
	}
}
