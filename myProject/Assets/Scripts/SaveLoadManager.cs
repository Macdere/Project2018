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
		FileStream stream = new FileStream (Application.dataPath + "/saveGame.sav", FileMode.Create);

		PlayerData data = new PlayerData ();

		bf.Serialize (stream, data);
		stream.Close ();

		Debug.Log (Application.dataPath);
		Debug.Log ("Game Saved");
	}

	public static object[] LoadGame(){
		if (File.Exists (Application.dataPath + "/saveGame.sav")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.dataPath + "/saveGame.sav", FileMode.Open);

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
			float x = playerObject.transform.position.x;
			float y = playerObject.transform.position.y;
			float z = playerObject.transform.position.z;

			int actualHealth = playerStats.instance.GetCurrentHealth();
			int index = SceneManager.GetActiveScene().buildIndex;

			gameInfo[0] = x ; // Position player
			gameInfo[1] = actualHealth; // CurrentHealth Player
			//gameInfo[2] = inventorySystem.instance.inventory ; // Inventory
			//gameInfo[3] = equipmentArray; // Equipment can't be serialize need an alternative same for inventory
			gameInfo[2] = PlayerManager.instance.Save1; // bool Camp1
			gameInfo[3] = PlayerManager.instance.Save2; // bool Camp2
			gameInfo[4] = PlayerManager.instance.Save3; // bool Camp3
			gameInfo[5] = PlayerManager.instance.Save4; // bool Camp4
			gameInfo[6] = index; // set the scene we saved in.
			gameInfo[7] = y ; // Position player
			gameInfo[8] = z ; // Position player

		}
	}


}
