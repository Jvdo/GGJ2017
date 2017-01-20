using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyAnalysis : MonoBehaviour {

	enum State
	{
		Preparing,
		Recoding,
		Processing,
	}

	AudioSource aud;

	State currentState;
	float timeActive;
	string audioDeviceName;

	// Use this for initialization
	void Start () {

		audioDeviceName = Microphone.devices[0];

		currentState = State.Preparing;
		aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		timeActive += Time.deltaTime;

		switch(currentState)
		{
		case State.Preparing:			
			aud.clip = Microphone.Start(audioDeviceName, true, 1, 44100);
			aud.Play();
			timeActive = 0.0f;
			currentState = State.Recoding;
			break;

		case State.Recoding:
			if (timeActive >= 1.0f)
			{
				Microphone.End(audioDeviceName);
				currentState = State.Processing;
			}
			break;

		case State.Processing:
			{
				print("frequency: " + aud);
				currentState = State.Preparing;
			}
			break;
		}
	}
}
