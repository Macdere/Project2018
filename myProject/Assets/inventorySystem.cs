using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour {

	private List<Object> inventory = new List<Object> ();

	public GameObject keyTrigger;
	public GameObject bagTrigger;

	public GameObject schoolBag;
	public GameObject key;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!bagTrigger.activeInHierarchy && !schoolBag.activeInHierarchy){
			var g = Resources.FindObjectsOfTypeAll(typeof(GameObject));
			Object nb1 = g[0];
			inventory.Add(nb1);
			Debug.Log(nb1);
			Debug.Log(inventory[0]);
		}

		if(!keyTrigger.activeInHierarchy && !key.activeInHierarchy){
			var g = Resources.FindObjectsOfTypeAll(typeof(GameObject));
			Object obj2 = g [1];
			inventory.Add(obj2);
			Debug.Log(obj2);
			Debug.Log(inventory[1]);
		}
	}
}
