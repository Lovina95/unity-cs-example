using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using winston.games.simpletap;

public class ScoreAnim : MonoBehaviour {

	private int count;
	private int prevCount;
	
	public UILabel ScoreLabel;

	void Start () {
		getAnimScore ();
	}

	protected void OnDesrtoy() {
		ScoreLabel = null;
	}

	public void Intro() {
		StartCoroutine(_AnimIn());
	}

	private IEnumerator _AnimIn() {
		prevCount = int.Parse(SimpleTapController.Instance.getScore);
		count = int.Parse(ScoreLabel.text);
		ScoreLabel.text = "0";
		yield return new WaitForEndOfFrame();

		var delay = 0f;
		delay += .25f;

		DOTween.To (() => count, newValue => ScoreLabel.text = newValue.ToString (), prevCount, 0.5F)
			.SetDelay (delay)
			.OnComplete(() => SendMessage("OnAnimComplete",	SendMessageOptions.DontRequireReceiver));
	}

	public String getAnimScore() {
		if (!ScoreLabel.text.Equals ("0"))
			return ScoreLabel.text;
		else
			return count.ToString ();
	}

	public String getScore{
		get{
			return getAnimScore();
		}
	}
}
