using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManage : MonoBehaviour {

	#region Singleton
	public static DialogueManage instance;
	void Awake(){
		instance = this;
	}
	#endregion

	private Queue<string> sentences;

	public Text NPCName;
	public Text textDialogue;

	public Animator anim;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	public void startDialogue(Dialogue dialogue){

		anim.SetBool ("isOpen", true);

		FindObjectOfType<audioManager> ().Play ("openDialogue");

		NPCName.text = dialogue.name;

		sentences.Clear ();

		foreach(string s in dialogue.sentences){
			sentences.Enqueue (s);
		}

		displayNextSentence ();
	}

	public void displayNextSentence(){
		if (sentences.Count == 0) {
			endDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	public void endDialogue(){
		StopAllCoroutines ();
		anim.SetBool ("isOpen", false);
	}

	IEnumerator TypeSentence(string sentence){
		textDialogue.text = "";
		foreach (char c in sentence.ToCharArray()) {
			textDialogue.text += c;
			yield return null;
		}
	}

}
