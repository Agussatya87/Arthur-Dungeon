using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int maxJumps = 2;
    private int jumpsRemaining;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip Player
        if (horizontalInput > 0.01f)
            spriteRenderer.flipX = false;
        else if (horizontalInput < -0.01f)
            spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
                jumpsRemaining = maxJumps - 1;
            }
            else if (jumpsRemaining > 0)
            {
                Jump();
                jumpsRemaining--;
            }
        }

        //Set animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpsRemaining = maxJumps;
        }
        else if (collision.gameObject.tag == "Rintangan")
        {
            grounded = true;
            jumpsRemaining = maxJumps;
        }
    }
}
