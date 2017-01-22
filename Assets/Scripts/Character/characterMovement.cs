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

    Vector3 SpawnPos;

    ParticleSystem pSystem;

    Component[] allSprites;

    public AudioClip[] jumpClips;
    public AudioClip[] deathClips;
    public AudioClip collisionClip;
    public AudioClip[] landClips;

    Animator animator;
    // Use this for initialization
    void Start()
    {
        SpawnPos = transform.position;
        pSystem = GetComponentInChildren<ParticleSystem>();
        allSprites = GetComponentsInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            move = Input.GetAxis("Horizontal");

            if (Input.GetKey("left"))
            {
                move -= 1f;
            }

            if (Input.GetKey("right"))
            {
                move += 1f;
            }

            move = Mathf.Clamp(move, -1f, 1f);
            if (move != 0)
                animator.SetBool("moving", true);
            else
                animator.SetBool("moving", false);
            if(grounded)
                animator.SetBool("jumping", false);
            else
                animator.SetBool("jumping", true);

            if (move > 0.01f)
            {
                foreach (var sprite in allSprites)
                {
                    SpriteRenderer spriteRender = sprite as SpriteRenderer;
                    if (!spriteRender.tag.Equals("Background"))
                    {
                        spriteRender.flipX = false;
                    }
                }
            }

            if (move < -0.01f)
            {
                foreach (var sprite in allSprites)
                {
                    SpriteRenderer spriteRender = sprite as SpriteRenderer;
                    if (!spriteRender.tag.Equals("Background"))
                    {
                        spriteRender.flipX = true;
                    }

                }
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxMovespeed, GetComponent<Rigidbody2D>().velocity.y);
            move *= 0.3f;
            if (GetComponent<Rigidbody2D>().velocity.y > 1) { grounded = false; }
            if (grounded && (Input.GetButton("Fire1") || Input.GetKey("up")) && GetComponent<Rigidbody2D>().velocity.y < 1)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                grounded = false;
                int jumpSoundNumber = Random.Range(0, jumpClips.Length - 1);
                GetComponent<AudioSource>().PlayOneShot(jumpClips[jumpSoundNumber]);
            }
        }
        if (Input.GetButton("Cancel"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level Select");
        }
    }

    public void Die()
    {
        canMove = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine("Respawn");
    }

	public void EndLevel()
	{
		canMove = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

    IEnumerator Respawn()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        pSystem.Emit(20);
        int deathSoundNumber = Random.Range(0, deathClips.Length - 1);
        GetComponent<AudioSource>().PlayOneShot(deathClips[deathSoundNumber]);

        foreach (SpriteRenderer sprity in allSprites)
        {
            sprity.enabled = false;
        }
        yield return new WaitForSeconds(2f);
        GetComponent<Rigidbody2D>().gravityScale = 2;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.position = SpawnPos;

        foreach (SpriteRenderer sprity in allSprites)
        {
            sprity.enabled = true;
        }
        //pSystem.Emit(20);

        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }

    public void SetSpawnPos(Vector3 newPos)
    {
        SpawnPos = newPos;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D pointy in col.contacts)
        {
            if (col.contacts[0].normal.y != 1.0f)
            {
                GetComponent<AudioSource>().PlayOneShot(collisionClip);
                break;
            }
            else
            {
                int landSoundNumber = Random.Range(0, landClips.Length - 1);
                GetComponent<AudioSource>().PlayOneShot(landClips[landSoundNumber]);
            }

        }
        Camera.main.GetComponent<ScreenShake>().SetShake(0.15f, 0.03f);
    }
}
