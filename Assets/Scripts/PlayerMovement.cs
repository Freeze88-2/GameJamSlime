using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 movement;
    private TrailRenderer trail;

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
    private float maxGravity = 8;
    private float timer = 0;
    private bool jump;
    private bool grabWall;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = transform.GetChild(0).gameObject.GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        grabWall = Input.GetKey(KeyCode.W);
        isGrounded = Physics2D.Raycast(transform.position, -transform.up, 0.8f,
                     LayerMask.GetMask("Ground"));
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
    }
}
