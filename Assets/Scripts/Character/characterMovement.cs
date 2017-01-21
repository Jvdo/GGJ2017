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

    ParticleSystem pSystem;

    Component[] allSprites;
    // Use this for initialization
    void Start()
    {
        SpawnPos = transform.position;
        pSystem = GetComponentInChildren<ParticleSystem>();
        allSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            move = Input.GetAxis("Horizontal");
            //if (Input.GetKey("left"))
            //{
            //    move = -1;
            //}

            //if (Input.GetKey("right"))
            //{
            //    move = 1;
            //}
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxMovespeed, GetComponent<Rigidbody2D>().velocity.y);
            move *= 0.3f;

            if (grounded && Input.GetButton("Fire1") && GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                grounded = false;
            }
        }
    }
    public void Die()
    {
        canMove = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        pSystem.Emit(20);
        foreach (SpriteRenderer sprity in allSprites)
        {
            sprity.enabled = false;
        }
        yield return new WaitForSeconds(2f);

        transform.position = SpawnPos;

        foreach (SpriteRenderer sprity in allSprites)
        {
            sprity.enabled = true;
        }
        pSystem.Emit(20);

        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }

    public void SetSpawnPos(Vector3 newPos)
    {
        SpawnPos = newPos;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
                Camera.main.GetComponent<ScreenShake>().SetShake(0.15f, 0.03f);
    }
}
