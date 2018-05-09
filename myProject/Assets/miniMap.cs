using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour {

	public Transform player;

	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;

		// if I need the camera to rotate with the player.
		//transform.rotation = Quaternion.Euler (90f, player.eulerAngles.y, 0f);
	}
}
