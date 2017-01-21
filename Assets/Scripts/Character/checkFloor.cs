using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFloor : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "MovingPlatform")
            transform.parent.parent = coll.transform;
        //else
        //    transform.parent.parent = coll.transform.parent;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        GetComponentInParent<characterMovement>().grounded = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        transform.parent.parent = null;
    }
}
