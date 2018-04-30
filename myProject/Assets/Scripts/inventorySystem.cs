using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySystem : MonoBehaviour {

	#region Singleton
	// Singleton that allows me to be sure I have only 1 instance of inventory available all the time

	public static inventorySystem instance;

	void Awake(){
		if (instance != null) {
			Debug.LogWarning("More than 1 instance of Inventory found");
			return;
		}

		instance = this;
	}

	#endregion

	public List<Items> inventory = new List<Items>();
	public static List<string> invent = new List<string>(); // List to keep available the first version of the appartement

	public int maxSlots = 10;

	// That will permits me to trigger teh modification when something happend in the inventory.
	// for example if I remove an object from the UI with a red cross for example that will trigger
	// this event and I will be able to call the remove function
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public bool Additem(Items item){
		if (!item.isDefaultItem) {
			if(inventory.Count >= maxSlots){
				Debug.Log ("Not enough space in the Inventory");
				return false;
			}

			inventory.Add (item);

			if (onItemChangedCallback != null) {
				onItemChangedCallback.Invoke ();
			}
		}
		return true;
	}

	// Method to keep available the first version of the appartement
	public static void Add(string tag){
		invent.Add (tag);
	}

	public void Remove(Items item){
		inventory.Remove(item);

		if (onItemChangedCallback != null) {
			onItemChangedCallback.Invoke ();
		}
	}


}
