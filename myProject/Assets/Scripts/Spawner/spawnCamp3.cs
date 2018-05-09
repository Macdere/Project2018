using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCamp3 : MonoBehaviour {

	public GameObject healthPrefab;

	public Vector3 center;
	public Vector3 size;

	public static int count;

	public float bonusTime = 10f;
	private int nbrBonus = 2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if ((count < nbrBonus) && (bonusTime < 0)) {
			spawnHealth ();
			bonusTime = 10f;
		} else {
			if(count < nbrBonus){
				bonusTime -= Time.deltaTime;
			}
		}
	}

	public void spawnHealth(){
		Vector3 pos = center + new Vector3 (Random.Range (-size.x / 2, size.x / 2), 1f, Random.Range (-size.z / 2, size.z / 2));

		Instantiate (healthPrefab, pos, Quaternion.identity);

		count++;
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1, 0, 0, 0.2f);
		Gizmos.DrawCube(center, size);
	}
}
