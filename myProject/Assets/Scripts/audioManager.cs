using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour {

	public audioSound[] sounds;

	public static audioManager instance;

	// Use this for initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach(audioSound s in sounds){
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start(){
		Play ("Theme");
	}

	public void Play (string name) {
		audioSound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Soud " + name + " not found.");
			return;
		}
		s.source.Play ();
	}

	public void PlayWithTime (string name, float delay) {
		audioSound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("Soud " + name + " not found.");
			return;
		}
		s.source.PlayDelayed (delay);
	}

	// FindObjectOfType<audioManager>().Play("name");
}
