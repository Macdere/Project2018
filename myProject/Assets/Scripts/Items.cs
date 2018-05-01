using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject {

	new public string name = "New Item";
	public Sprite icon = null; // for the inventory to add icons in it
	public bool isDefaultItem = false;


	public virtual void Use (){
		// Something will happened concidering the object we use from the Inventory

		Debug.Log (name + " use");
	}
}
