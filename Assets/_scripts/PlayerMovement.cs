using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        //Set animator
        anim.SetBool("run", horizontalInput != 0);
    }
}
