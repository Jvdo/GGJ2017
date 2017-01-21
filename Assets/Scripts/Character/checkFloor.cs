using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFloor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        GetComponentInParent<characterMovement>().grounded = true;
    }
}
