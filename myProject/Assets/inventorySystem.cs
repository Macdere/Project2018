using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour {

	private List<GameObject> inventory = new List<GameObject> ();

	public GameObject keyTrigger;
	public GameObject bagTrigger;

	public GameObject schoolBag;
	public GameObject key;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(bagTrigger.activeInHierarchy && schoolBag.activeInHierarchy){
			GameObject g = GameObject.Find ("schoolBag");
			inventory.Add(g);
			Debug.Log(inventory[0]);
		}

		if(keyTrigger.activeInHierarchy && key.activeInHierarchy){
			GameObject g = GameObject.Find ("keyPoly");
			inventory.Add(g);
			Debug.Log(inventory[0]);
		}
	}
}
