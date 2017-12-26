using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Message : MonoBehaviour {
	
	private UIWidget _widget;
	private Vector3 _initPos;
	private Tween _tween;

	[SerializeField] protected float _time = 0.25f;
	[SerializeField] protected float _distance = 100;

	protected void Awake() {
		_widget = GetComponent<UIWidget>();
		_initPos = transform.localPosition;
	}

	public void Play() {
		if (!gameObject.activeInHierarchy)
			gameObject.SetActive(true);
		Stop();
		StartCoroutine("_Animation");
	}

	public void Stop() {
		if (IsPlaying){
			_tween.Kill();
			StopCoroutine("_Animation");
			IsPlaying = false;
			_widget.alpha = 0;
		}
	}

	protected void OnDisable() {
		Stop();
	}

	protected IEnumerator _Animation() {
		IsPlaying = true;

		_widget.alpha = 0;
		_widget.transform.localPosition = _initPos + Vector3.left * _distance;
		DOTween.To(() => 0F, value => _widget.alpha = value, 1F, 0.5F)
			.SetEase(Ease.OutSine);
		_tween = _widget.transform.DOLocalMoveX(_initPos.x, _time).SetEase(Ease.OutSine);

		yield return new WaitForSeconds(2f);

		DOTween.To(() => 1F, value => _widget.alpha = value, 0F, 0.5F)
			.SetEase(Ease.OutSine);
		_tween = _widget.transform.DOLocalMoveX(_initPos.x + _distance, _time).SetEase(Ease.InSine)
			.OnComplete(() => gameObject.SetActive(false));

	}

	public bool IsPlaying { get; private set; }
}
