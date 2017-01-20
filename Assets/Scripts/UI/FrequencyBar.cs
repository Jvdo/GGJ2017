using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrequencyBar : MonoBehaviour {

	Speach speach;

	public Image foreground;

	// Use this for initialization
	void Start () {
		speach = FindObjectOfType<Speach>();
	}
	
	// Update is called once per frame
	void Update () {
		foreground.fillAmount = Mathf.Clamp01(speach.freqHight/50.0f);
	}
}
