using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpHeight = 10f;
    public bool grounded;
    public Transform groundProbe;
    public float groundProbeRadius = 0.1f;
    public LayerMask groundLayer;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
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
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            anim.SetTrigger("Jump");
        }

        grounded = Physics2D.OverlapCircle(groundProbe.position, groundProbeRadius, groundLayer);
    }
}
