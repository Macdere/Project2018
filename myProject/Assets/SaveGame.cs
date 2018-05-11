using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform player;

	public void Save(){
		SaveLoadManager.SaveGame ();
	}

	public void Load(){
		object[] loadedInfos = SaveLoadManager.LoadGame ();

		Vector3 pos = player.transform.position;

		pos = new Vector3((float)loadedInfos [0],(float)loadedInfos [9],(float)loadedInfos [10]); // Load all the informations in the last Save
		playerStats.instance.setCurrentHealth((int)loadedInfos[1]);
		//inventorySystem.instance.inventory = (List<Items>)loadedInfos [2];
		//EquipmentManager.instance.setEquipmentArray((Equipment[])loadedInfos [3]);
		PlayerManager.instance.Save1 = (bool)loadedInfos [4];
		PlayerManager.instance.Save2 = (bool)loadedInfos [5];
		PlayerManager.instance.Save3 = (bool)loadedInfos [6];
		PlayerManager.instance.Save4 = (bool)loadedInfos [7];
		SceneManager.LoadScene((int)loadedInfos [8]);

	}

}
