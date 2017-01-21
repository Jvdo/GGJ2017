using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{

    public bool grounded;
    int maxMovespeed = 5;
    int jumpForce = 400;

    float move;

    public GameObject AudioObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
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
    public void Die()
    {
        StartCoroutine("RestartLevel");
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
