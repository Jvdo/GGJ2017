using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFloor : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Camera.main.GetComponent<ScreenShake>().SetShake(0.15f, 0.03f);
        if (coll.tag == "MovingPlatform")
            transform.parent.parent = coll.transform;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (!coll.isTrigger)
            GetComponentInParent<characterMovement>().grounded = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        transform.parent.parent = null;
    }
}
