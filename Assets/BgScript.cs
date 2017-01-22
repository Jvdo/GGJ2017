using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    Transform camTransform;

    Vector3 startPos;

    public Vector3 strength = new Vector3(0.7f,0,0);

    // Use this for initialization
    void Start()
    {
        camTransform = Camera.main.transform;
        Vector3 gf = camTransform.position;
        gf.Scale(strength);
        startPos = transform.localPosition - gf;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gf = camTransform.position;
        gf.Scale(strength);
        transform.localPosition = gf + startPos;
    }
}
