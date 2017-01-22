using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    GameObject player;
    public AudioClip[] laserClips;
    void Start()
    {
        player = FindObjectOfType<characterMovement>().gameObject;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<characterMovement>().Die();
            Camera.main.GetComponent<ScreenShake>().SetShake(0.4f, 0.2f);
        }
    }
    void Update()
    {
        if (GetComponent<AudioSource>())
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 10)
            {
                GetComponent<AudioSource>().mute = false;
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    int moveSoundNumber = Random.Range(0, laserClips.Length - 1);
                    GetComponent<AudioSource>().clip = laserClips[moveSoundNumber];
                    GetComponent<AudioSource>().Play();
                }
            }
            else
                GetComponent<AudioSource>().mute = true;
        }
    }
}