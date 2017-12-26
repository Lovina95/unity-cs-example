using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using games.simpletap;

public class TapForMusic : MonoBehaviour {

	public GameObject[] notes;
	public Transform notePosition;
	public GameObject instrument;
	private Animation anim;

	void Start() {
		anim = instrument.GetComponent<Animation> ();
		anim.Stop ();
	}

	void OnEnable() {
		SimpleTapController.Instance.resetCountClick ();
	}

	public void OnClick() {

		if(SimpleTapController.Instance.isVolumeOn == 1)
			SoundManagerScript.Instance.PlayMusic();
		ShowNotes();
		SimpleTapController.Instance.SuccessClick ();
	}

	private void ShowNotes() {
		int rndIndex = Random.Range (0, notes.Length);
		GameObject note = Instantiate (notes[rndIndex],
			notePosition.position,
			notes[rndIndex].transform.rotation) as GameObject;
		note.transform.SetParent (this.transform, true);
		Destroy (note, 4);
		int index = Random.Range(0, 4);
		string instrumentAnimName = "1";
		switch(index){
		case 0:
			instrumentAnimName = "1";
			break;
		case 1:
			instrumentAnimName = "2";
			break;
		case 2:
			instrumentAnimName = "3";
			break;
		}
		anim.Play (instrumentAnimName);
	}
}
