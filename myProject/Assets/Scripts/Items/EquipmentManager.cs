using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton
	public static EquipmentManager instance;
	void Awake(){
		instance = this;
	}
	#endregion
	// That callBack method will allow me to do something if something change in the inventory
	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	Equipment[] currentEquipment;

	inventorySystem inventory;

	void Start(){
		inventory = inventorySystem.instance;

		// This is the lenght of all the element in our array of Equipment.
		int numSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
	}

	// Take an item and insert in our Equipment array but at the right place. We use the index given by the Enum
	public void Equip (Equipment newItem){

		int slotIndex = (int)newItem.equipSlot;

		Equipment oldItem = null;

		// if the player already have something at thiis index, then that will swap the item without making it desepear.
		if (currentEquipment [slotIndex] != null) {
			
			oldItem = currentEquipment [slotIndex];
			inventory.Additem (oldItem);
		}

		if (onEquipmentChanged != null) {
			onEquipmentChanged.Invoke (newItem, oldItem);
		}

		currentEquipment [slotIndex] = newItem;

	}

	public void UnEquip(int slotIndex){
		if (currentEquipment [slotIndex] != null) {
			Equipment oldEquipment = currentEquipment[slotIndex];
			inventory.Additem (oldEquipment);

			currentEquipment [slotIndex] = null;

			if (onEquipmentChanged != null) {
				onEquipmentChanged.Invoke (null, oldEquipment);
			}
		}
	}

	public void UnEquipAll(){
		for (int i = 0; i < currentEquipment.Length; i++) {
			UnEquip (i);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.U)) {
			UnEquipAll ();
		}
	}

	public Equipment[] GetEquipmentArray(){
		return currentEquipment;
	}

	public void setEquipmentArray(Equipment[] equipment){
		currentEquipment = equipment;
	}

}
