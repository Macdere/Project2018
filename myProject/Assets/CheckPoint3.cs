using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint3 : MonoBehaviour {

	public GameObject EnemyOne;
	public GameObject EnemyTwo;
	public GameObject EnemyThree;
	public GameObject item;

	// Update is called once per frame
	void Update () {
		if (PlayerManager.instance.Save3) {

			EnemyOne.SetActive (false);
			EnemyTwo.SetActive (false);
			EnemyThree.SetActive (false);
			item.SetActive (false);
		} else {
			EnemyOne.SetActive (true);
			EnemyTwo.SetActive (true);
			EnemyThree.SetActive (true);
			item.SetActive (true);
		}
	}
}
