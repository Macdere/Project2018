using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour {

	public List<string> inventory;

	public GameObject keyTrigger;
	public GameObject bagTrigger;

	public GameObject schoolBag;
	public GameObject key;

	// Use this for initialization
	void Start () {
		inventory = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!bagTrigger.activeInHierarchy && !schoolBag.activeInHierarchy){
			inventory.Add("schoolBag");
			Debug.Log(inventory[0]);
		}

		if(!keyTrigger.activeInHierarchy && !key.activeInHierarchy){
			inventory.Add("key");
			Debug.Log(inventory[1]);
		}
	}
}
