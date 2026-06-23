using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 7f;

    public bool isGrounded = false;
    public bool isSprinting = false;
    public bool isJumping = false;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimations();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        isSprinting = Input.GetKey(KeyCode.LeftShift);

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
        }
    }

    void UpdateAnimations()
    {
        animator.SetBool("isMoving", Mathf.Abs(rb.velocity.x) > 0.1f);
        animator.SetBool("isGrounded", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            isJumping = false;
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