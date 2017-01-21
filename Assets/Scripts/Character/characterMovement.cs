using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{

    public bool grounded;
    public int maxMovespeed = 5;
    public int jumpForce = 450;

    float move;
    bool canMove = true;

    public GameObject AudioObject;
    Vector3 SpawnPos;

    // Use this for initialization
    void Start()
    {
        SpawnPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
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

            if (grounded && Input.GetKey("up") && GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                grounded = false;
            }
        }
    }
    public void Die()
    {
        canMove = false;
        GetComponent<Rigidbody2D>().velocity *= 0.35f;
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = SpawnPos;
        canMove = true;
    }

    public void SetSpawnPos(Vector3 newPos)
    {
        SpawnPos = newPos;
    }
}
