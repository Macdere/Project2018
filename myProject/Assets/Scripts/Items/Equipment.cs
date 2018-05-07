using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Items {

	public EquipmentSlot equipSlot;

	public int healthModifier;
	public int damageModifier;

	public override void Use(){

		base.Use ();
		EquipmentManager.instance.Equip (this);
		RemoveFromInventory ();

	}

}

public enum EquipmentSlot{Head, Chest, Glove, Feet, Weapon}