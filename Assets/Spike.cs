using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<characterMovement>().Die();
            Camera.main.GetComponent<ScreenShake>().SetShake(0.4f, 0.2f);
        }
    }
}