using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour {

    bool grounded;
    int maxMovespeed = 5;
    int jumpForce = 300;

    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;

    float move;

    public GameObject AudioObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //float move = 0;

        if (Input.GetKey("left"))
        {
            move = -1;
        }

        if (Input.GetKey("right"))
        {
            move = 1;
        }        
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxMovespeed, GetComponent<Rigidbody2D>().velocity.y);
        move *= 0.3f;

        if (grounded && Input.GetKey("up"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
        }
    }
}
