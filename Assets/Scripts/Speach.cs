﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Speach : MonoBehaviour
{
    public float freqHight;

    public float sensitivity = 100.0f;
    public float loudness = 0.0f;
    public float frequency = 0.0f;
    public int samplerate = 11024;
	public float loudnessThreshold = 0.1f;
	public float bucketThreshold = 0.0005f;
	bool inputValid;
	bool bucketValid;
	float frequencySample;

	string microphoneName;

	public float minFrequency = 120.0f;
	public float maxFrequency = 1500.0f;

    AudioSource aud;
    int index = 0;
    void Start()
    {
        aud = GetComponents<AudioSource>()[index];
        InvokeRepeating("StartRecording", 0, 10);
        InvokeRepeating("GetFundamentalFrequency", 0, 1.0f / 4f);

		microphoneName = Microphone.devices[0];
		print("microphone: "+microphoneName);
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
        //frequency = GetFundamentalFrequency();
        //print(freqHight);

		inputValid = loudness >= loudnessThreshold;
    }

	void FixedUpdate()
	{
		const float strength = 0.1f;
		if (inputValid)
		{
			frequency = Mathf.Lerp(frequency, frequencySample, strength);
		}
		else
		{
			frequency = Mathf.Lerp(frequency, 0f, strength);
		}
	}

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        aud.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    IEnumerator StartRecording()
    {
        aud = GetComponents<AudioSource>()[index];
		aud.clip = Microphone.Start(microphoneName, false, 10, samplerate);
        //aud.loop = true; // Set the AudioClip to loop
        //aud.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
        aud.Play(); // Play the audio source!
        index++;
        if (index > 1)
            index = 0;
        return null;
    }

    IEnumerator GetFundamentalFrequency()
    {
        float fundamentalFrequency = 0.0f;
		int numberOfSamples = 256;//8192/64;
        float[] data = new float[numberOfSamples];
        aud.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);
        float s = 0.0f;
        int i = 0;

		bucketValid = false;

        for (int j = 1; j < numberOfSamples; j++)
        {
			float bucketFreq = j * samplerate / numberOfSamples;
			if (bucketFreq >= minFrequency && bucketFreq <= maxFrequency)
			{
				if (s < data[j] && data[j] >= bucketThreshold)
	            {
	                s = data[j];
	                //print(s + " ---- " + j);
	                i = j;
					//print(data[j]);
					bucketValid = true;
	            }
			}
        }
        fundamentalFrequency = i * samplerate / numberOfSamples;
        freqHight = fundamentalFrequency;

		if (fundamentalFrequency != 5512 && inputValid)
		{
			frequencySample = fundamentalFrequency;
		}

        return null;
    }

    //    AudioSource aud;
    //    // Use this for initialization
    //    void Start () {
    //        aud = GetComponent<AudioSource>();
    //        aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
    //        aud.loop = true;
    //        while (!(Microphone.GetPosition(null) > 0)) { }
    //        aud.Play();
    //    }

    //	// Update is called once per frame
    //	void Update () {
    //        print(GetFundamentalFrequency());
    //	}

    //    float GetFundamentalFrequency()
    //    {
    //        float fundamentalFrequency = 0.0f;
    //        float[] data = new float[8192];
    //        aud.GetSpectrumData(data, aud.clip.channels, FFTWindow.BlackmanHarris);
    //        return fundamentalFrequency;
    //    }

	public bool IsInputValid() { return inputValid && bucketValid; }
}
