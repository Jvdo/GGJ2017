using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class speach : MonoBehaviour
{

    public float sensitivity = 100.0f;
    public float loudness = 0.0f;
    public float frequency = 0.0f;
    public int samplerate = 11024;

    AudioSource aud;
    void Start()
    {

        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start("Built-in Microphone", true, 10, samplerate);
        aud.loop = true; // Set the AudioClip to loop
        //aud.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
        aud.Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
        frequency = GetFundamentalFrequency();
        print(frequency);
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

    float GetFundamentalFrequency()
    {
        float fundamentalFrequency = 0.0f;
        int numberOfSamples = 8192/64;
        float[] data = new float[numberOfSamples];
        aud.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);
        float s = 0.0f;
        int i = 0;
        for (int j = 1; j < numberOfSamples; j++)
        {
            if (s < data[j])
            {
                s = data[j];
                i = j;
            }
        }
        fundamentalFrequency = i * samplerate / numberOfSamples;
        return fundamentalFrequency;
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
}
