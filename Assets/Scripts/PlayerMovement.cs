using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 movement;
    private TrailRenderer trail;
    private Animator anim;
    private SpriteRenderer sprite;

    [Header("Variables")]
    [Tooltip("Maximum air time")]
    [SerializeField] private float maxJumpTime = 5;
    [Tooltip("Maximum movement speed")]
    [SerializeField] private float speed = 10f;
    [Tooltip("Input multiplier while grabbing wall")]
    [SerializeField] private float inputScaler = 0.5f;
    [Tooltip("The speed gained when jump is pressed")]
    [SerializeField] private float jumpForce = 10f;

    private float inputH;
    private readonly float maxGravity = 8;
    private float timer = 0;
    private bool jump;
    private bool grabWall;
    private bool isGrounded;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trail = transform.GetChild(0).gameObject.GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        grabWall = Input.GetKey(KeyCode.W);
        isGrounded = Physics2D.Raycast(transform.position, -transform.up, 0.8f,
                     LayerMask.GetMask("Ground", "FloatingObject"));
    }
    private void FixedUpdate()
    {
        if (isGrounded) timer = 0;
        else if (!jump) timer = maxJumpTime;

        if (!grabWall)
        {
            rb.gravityScale = maxGravity;
            trail.emitting = false;
            movement.y = rb.velocity.y;

            if (jump && timer < maxJumpTime)
            {
                Mathf.Min(timer++, maxJumpTime);
                movement.y = jumpForce;
            }
        }
        else if (grabWall && !isGrounded)
        {
            trail.emitting = true;
            movement.y = rb.velocity.y;

            if (rb.gravityScale == maxGravity)
            {
                movement = Vector3.zero;
                rb.gravityScale = 0;
            }

            rb.gravityScale = Mathf.Min(rb.gravityScale + 0.01f, maxGravity - 0.1f);
            
            inputH *= inputScaler;
        }
        movement = new Vector3(inputH * speed, movement.y);

        rb.velocity = movement;
        if (inputH > 0)
        {
            sprite.flipX = true;
        }
        if (inputH < 0)
        {
            sprite.flipX = false;
        }
        anim.SetFloat("Jump", rb.velocity.y);
        anim.SetFloat("Walking", Mathf.Abs(inputH));
        anim.SetBool("IsGrounded", isGrounded);
    }
}
