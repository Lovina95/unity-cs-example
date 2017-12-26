using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using games.simpletap;

public class InstrumentsController : MonoBehaviour {

	public InstrumentType type;
	public GameObject checkIcon;
	private bool canBuy;
	private bool canPlay;

	List<string> list;

	void Start () {

	}

	protected void OnEnable() {
		list = new List<string> ();
		list.Clear ();
		list.AddRange(SimpleTapApi.Instance.getAvailableInstruments);
		if (type == InstrumentType.Drum && list.Contains("drum")) {
			checkIcon.SetActive (true);
		} else if (type == InstrumentType.Horn && list.Contains("french-horn")) {
			checkIcon.SetActive (true);
		} else if (type == InstrumentType.Trumpet && list.Contains("trumpet")) {
			checkIcon.SetActive (true);
		} else if (type == InstrumentType.Synthesizer && list.Contains("piano")) {
			checkIcon.SetActive (true);
		} else if (type == InstrumentType.Guitar && list.Contains("guitar")) {
			checkIcon.SetActive (true);
		} else if (type == InstrumentType.Violin && list.Contains("violoncello")) {
			checkIcon.SetActive (true);
		} else 
			checkIcon.SetActive (false);
	}

	public void GoToDetailes() {
		SimpleTapController.Instance.StateInstrumentDetailes (type);
	}

	public void BuyAndGoToGamePlay() {
		Debug.Log ("type: " + type);
		string typeBuy = "guitar";
		canBuy = false;
		if (type == InstrumentType.Drum && !list.Contains("drum")) {
			typeBuy = "drum";
			canBuy = true;
		} else if (type == InstrumentType.Horn && !list.Contains("french-horn")) {
			typeBuy = "french-horn";
			canBuy = true;
		} else if (type == InstrumentType.Trumpet && !list.Contains("trumpet")) {
			typeBuy = "trumpet";
			canBuy = true;
		} else if (type == InstrumentType.Synthesizer && !list.Contains("piano")) {
			typeBuy = "piano";
			canBuy = true;
		} else if (type == InstrumentType.Guitar && !list.Contains("guitar")) {
			typeBuy = "guitar";
			canBuy = true;
		} else if (type == InstrumentType.Violin && !list.Contains("violoncello")) {
			typeBuy = "violoncello";
			canBuy = true;
		}
		if (canBuy)
			SimpleTapApi.Instance.BuyNewInstrument (typeBuy, type);
	}

	public void GoToPlayGame() {
		Debug.Log ("type: " + type);
		canPlay = false;
		if (type == InstrumentType.Drum && list.Contains("drum")) {
			canPlay = true;
		} else if (type == InstrumentType.Horn && list.Contains("french-horn")) {
			canPlay = true;
		} else if (type == InstrumentType.Trumpet && list.Contains("trumpet")) {
			canPlay = true;
		} else if (type == InstrumentType.Synthesizer && list.Contains("piano")) {
			canPlay = true;
		} else if (type == InstrumentType.Guitar && list.Contains("guitar")) {
			canPlay = true;
		} else if (type == InstrumentType.Violin && list.Contains("violoncello")) {
			canPlay = true;
		}
		if (canPlay)
			SimpleTapController.Instance.GoToPlayGame(type);
	}
}
