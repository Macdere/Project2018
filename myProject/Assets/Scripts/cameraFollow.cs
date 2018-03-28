using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	[Header("Target")]
	public Transform target;
	[Header("Distances")]
	public float distance = 3f;
	public float minDistance = 1.5f;
	public float maxDistance = 6f;
	public Vector3 offset;
	[Header("Speeds")]
	public float smoothSpeed = 5f;
	public float scrollSensitivity = 1;

	void Start(){

	}

	void LateUpdate(){
		if (!target) {
			print ("No target found");
			return;
		}

		float num = Input.GetAxis ("Mouse ScrollWheel");
		distance -= num * scrollSensitivity;
		distance = Mathf.Clamp (distance, minDistance, maxDistance);

		Vector3 pos = target.position + offset;
		pos -= transform.forward * distance;

		transform.position = Vector3.Lerp (transform.position, pos, smoothSpeed * Time.deltaTime);

	}
}
