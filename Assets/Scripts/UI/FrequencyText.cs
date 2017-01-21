using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FrequencyText : MonoBehaviour {

	Speach speach;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		speach = FindObjectOfType<Speach>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = string.Format("Frequency: {0}Hz", speach.frequency);
	}
}
