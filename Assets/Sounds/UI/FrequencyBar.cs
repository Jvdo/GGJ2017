using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrequencyBar : MonoBehaviour {

	Speach speach;

	public Image foreground;

	public float maxFreq = 1000.0f;
	public float minFreq = 200.0f;

	// Use this for initialization
	void Start () {
		speach = FindObjectOfType<Speach>();
	}

	// Update is called once per frame
	void Update () {
		float factor = Mathf.InverseLerp(minFreq, maxFreq, speach.frequency);
        factor = Mathf.Clamp01(factor);
        foreground.fillAmount = factor;
	}
}
