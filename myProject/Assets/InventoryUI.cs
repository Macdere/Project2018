using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
	public Transform itemsParent;
	public GameObject inventoryUI;

	inventorySystem inventory;

	InventorySlot[] slots;

	// Use this for initialization
	void Start () {
		inventory = inventorySystem.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			inventoryUI.SetActive (!inventoryUI.activeSelf);
		}
	}

	void UpdateUI(){
		for (int i = 0; i < slots.Length; i++) {
			if (i < inventory.inventory.Count) {
				slots [i].addItem (inventory.inventory [i]);
			} else {
				slots [i].ClearSlot ();
			}
		}
	}
}
