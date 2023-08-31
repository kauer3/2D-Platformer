using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpHeight = 1f;

    public bool grounded;
    public float groundProbeRadius = 0.1f;
    public LayerMask groundLayer;

    public Transform groundProbe;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int jumpCounter = 0;

    private string dashState = "ready";
    private float dashTimer = 0;
    private float dashVelocity;
    private float maxDash = 0.5f;
    public Vector2 savedVelocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim.SetBool("Running", false);
    }

    void Update()
    {
        CheckIfGrounded();
        HandleDash();
        if (dashState != "dashing")
        {
            HandleMovement();
        }
        HandleAnimations();
    }

    void HandleAnimations()
    {
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
        
    }

    void HandleMovement()
    {
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Running", false);

        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            anim.SetBool("Running", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("Running", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            anim.SetTrigger("Jump");
            jumpCounter++;
        }
    }

    void CheckIfGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundProbe.position, groundProbeRadius, groundLayer);

        if (grounded && jumpCounter > 0)
        {
            jumpCounter = 0;
        }
    }

    void HandleDash()
    {
        if (dashState == "ready")
        {
            if (Input.GetMouseButtonDown(1) && !grounded)
            {
                savedVelocity = rb.velocity;
                if (savedVelocity.x != 0)
                {
                    dashVelocity = savedVelocity.x > 0 ? 20 : -20;
                }
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(dashVelocity, 0f);
                dashState = "dashing";
                Debug.Log(dashState);
            }
        }
        else if (dashState == "dashing")
        {
            dashTimer += Time.deltaTime * 3;
            if (dashTimer >= maxDash)
            {
                dashTimer = maxDash;
                rb.gravityScale = 2;
                rb.velocity = savedVelocity;
                dashState = "cooldown";
                Debug.Log(dashState);
            }
        }
        else if (dashState == "cooldown")
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                dashTimer = 0;
                dashState = "ready";
                Debug.Log(dashState);
            }
        }
    }
}
