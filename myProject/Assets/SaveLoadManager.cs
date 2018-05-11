using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveLoadManager {


	public static void SaveGame(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/saveGame.sav", FileMode.Create);

		PlayerData data = new PlayerData ();

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static object[] LoadGame(){
		if (File.Exists (Application.persistentDataPath + "/saveGame.sav")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/saveGame.sav", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
			return data.gameInfo;

		} else {
			Debug.LogError ("File does not exist");
			return new object[8];
		}
	}


	[Serializable]
	public class PlayerData{
		
		
		public object[] gameInfo;

		public PlayerData(){
			gameInfo = new object[9];

			var playerObject = GameObject.Find("ThirdPersonController");
			Vector3 pos = playerObject.transform.position;

			int actualHealth = playerStats.instance.GetCurrentHealth();
			Equipment[] equipmentArray = EquipmentManager.instance.GetEquipmentArray();
			int index = SceneManager.GetActiveScene().buildIndex;

			gameInfo[0] = pos ; // Position player
			gameInfo[1] = actualHealth; // CurrentHealth Player
			gameInfo[2] = inventorySystem.instance.inventory ; // Inventory
			gameInfo[3] = equipmentArray; // Equipment
			gameInfo[4] = PlayerManager.instance.Save1; // bool Camp1
			gameInfo[5] = PlayerManager.instance.Save2; // bool Camp2
			gameInfo[6] = PlayerManager.instance.Save3; // bool Camp3
			gameInfo[7] = PlayerManager.instance.Save4; // bool Camp4
			gameInfo[8] = index; // set the scene we saved in.

		}
	}


}
