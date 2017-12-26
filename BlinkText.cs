using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkText : MonoBehaviour {
	protected float x0;
	protected float y0;
	protected float t;

	[SerializeField]
	protected float _yDelta = 4F;
	[SerializeField]
	protected float _timeDelta = 0.15F;

	[SerializeField]
	protected float _yScale = 4F;
	[SerializeField]
	protected float _timeScale = 0.15F;

	protected void Awake() {
		x0 = transform.localScale.x;
		y0 = transform.localPosition.y;
	}

	protected void Update() {
		var pos = transform.localPosition;
		var scale = transform.localScale;
		pos.y = y0 + Mathf.Sin(t += _timeDelta) * _yDelta;
		scale.x = x0 + Mathf.Sin(t += _timeScale) * _yScale;
		transform.localPosition = pos;
		transform.localScale = scale;
	}
}
