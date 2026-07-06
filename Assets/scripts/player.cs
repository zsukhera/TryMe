using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //game over screen
    public GameObject gameoverScreen;

    public float movementSpeed = 15f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 7f;

    public bool isGrounded = true;
    public bool isSprinting = false;
    public bool isJumping = false;
    public bool isDead = false;
    private Rigidbody2D rb;
    private Animator animator;

    //audio manager
    public GameObject audiomanager;
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audiomanager = GameObject.Find("audioManager");
        if (!audiomanager)
            Debug.Log("no audio manager, received by the player");
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimations();
        Attack();
    }

    //plays the isdead animation
    void playDead()
    {
        if(isDead)
        {
            animator.SetBool("isDead", true);
        }
    }

    void Attack()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("attack");
        }
    }


    public void cleanup()
    {
        // Stop movement
        rb.velocity = Vector2.zero;

        // Disable physics
        rb.simulated = false;

        // Disable collisions
        GetComponent<Collider2D>().enabled = false;

        // Disable this script
        enabled = false;

        // Optionally hide the player immediately
        gameObject.SetActive(false);

        //the gameover screen will be set
        gameoverScreen.SetActive(true);
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        //isSprinting = Input.GetKey(KeyCode.LeftShift);

        float speed = movementSpeed;

        if (isSprinting)
        {
            speed *= sprintMultiplier;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Flip sprite
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Jump()
    {
        //a condition here that makes sure that jump is only done when no movement is being made
        //&& Mathf.Approximately(rb.velocity.x, 0)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isMoving", false);
            isGrounded = false;
            isJumping = true;
            audiomanager.GetComponent<audioScript>().PlayJumpSound();
        }
    }

    void UpdateAnimations()
    {
        animator.SetBool("isMoving", Mathf.Abs(rb.velocity.x) > 0.1f);
        animator.SetBool("isGrounded", isGrounded);
        if(isDead)
            playDead();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            isJumping = false;
        }

        if(collision.gameObject.CompareTag("trap"))
        {
            isDead = true;
            audiomanager.GetComponent<audioScript>().playDeathSound();
            audiomanager.GetComponent<audioScript>().PlayGameOverSound();
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}