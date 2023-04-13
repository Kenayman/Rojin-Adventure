using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator animator;
    private SpriteRenderer sprite;

    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float moveForce = 3f;
    private bool isOnLand;

    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    private void Controls()
    {
        MovementState state;

        if (Input.GetKeyDown(KeyCode.Space) && isOnLand==true)
        {

            playerRb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            
            

        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(horizontalInput * 7, playerRb.velocity.y);

        if (horizontalInput > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            isOnLand = true;


        }

        else if (horizontalInput < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            isOnLand = true;


        }
        else
        {
            state = MovementState.idle;
            isOnLand=true;


        }

        if(playerRb.velocity.y > 0.1f ) {
            state = MovementState.jumping;
            isOnLand = false;
        }
        if (playerRb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
            isOnLand = false;
        }


        animator.SetInteger("state", (int)state);
    }
}
