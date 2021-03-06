﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounder : MonoBehaviour {

    Speach speach;
    public float targetFrequencyMin = 500;
    characterMovement player;
    public bool clockwise;
    // Use this for initialization
    void Start () {
        speach = FindObjectOfType<Speach>();
        player = FindObjectOfType<characterMovement>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (speach.frequency >= targetFrequencyMin && Vector2.Distance(player.transform.position, transform.position) < 15)
        {
            float toRotate = Mathf.Clamp(speach.frequency, 200, 1000);
            toRotate /= 250;
            if (clockwise)
                toRotate *= -1;
            transform.Rotate(0, 0, toRotate);
        }
	}
}
