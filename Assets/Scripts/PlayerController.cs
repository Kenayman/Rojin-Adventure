using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float moveForce = 3f;
    [SerializeField] private AudioSource jump;
    [SerializeField] private LayerMask jumpable;

    private enum MovementState { idle, running, jumping, falling, attack }
    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    private void Controls()
    {
        MovementState state;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jump.Play();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
        }



        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * 7, playerRb.velocity.y);

        if (horizontalInput > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (horizontalInput < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(playerRb.velocity.y > 0.1f ) {
            state = MovementState.jumping;
        }
        if (playerRb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }



        animator.SetInteger("state", (int)state);
    }

    private void Atack()
    {
            
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, jumpable);
        

    }
}
