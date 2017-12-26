using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using games.simpletap;

public class SoundManagerScript : MonoBehaviour {
	public static SoundManagerScript Instance;

	AudioSource _source;
	public AudioClip[] guitarClip;
	public AudioClip[] violinClip;
	public AudioClip[] drumClip;
	public AudioClip[] hornClip;
	public AudioClip[] trumpetClip;
	public AudioClip[] synthesizerClip;

	void Start () {
		Instance = this;
		_source = GetComponent<AudioSource> ();
	}

	public void PlayMusic() {
		AudioClip[] audioClip = null;
		switch(SimpleTapController.Instance.getSelectedInstrumentType) {
			case InstrumentType.Drum:
				audioClip = drumClip;
				break;
			case InstrumentType.Horn:
				audioClip = hornClip;
				break;
			case InstrumentType.Trumpet:
				audioClip = trumpetClip;
				break;
			case InstrumentType.Synthesizer:
				audioClip = synthesizerClip;
				break;
			case InstrumentType.Guitar:
				audioClip = guitarClip;
				break;
			case InstrumentType.Violin:
				audioClip = violinClip;
				break;
		}
		int index = UnityEngine.Random.Range (0, audioClip.Length);
		_source.clip = audioClip[index];
		_source.Play ();
	}

	public void StopMusic() {
		_source.Stop ();
	}
}
