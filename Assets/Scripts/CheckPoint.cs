using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{


    public Sprite red;
    public Sprite green;

    ParticleSystem pSystem;

    void Start()
    {
        pSystem = GetComponentInChildren<ParticleSystem>();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<characterMovement>().SetSpawnPos(transform.position);
            GetComponentsInChildren<SpriteRenderer>()[1].sprite = green;
            GetComponent<BoxCollider2D>().enabled = false;
            pSystem.Emit(20);
        }
    }
}
