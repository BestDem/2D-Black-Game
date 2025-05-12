using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false; 
    [SerializeField] private bool canMove = true;

    [Header("Settings")]
    [SerializeField] private Animator animator; 
    [SerializeField] private SpriteRenderer playerRotation;
    [SerializeField] private float jumpOffSet = 0.2f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckInterval = 0.1f; // Интервал проверки в секундах
    private float nextGroundCheckTime;
    private Rigidbody2D rb;
    private Transform player;

    public bool IsLookRight => !playerRotation.flipX;
    
    private void FixedUpdate()
    {
        if (Time.time >= nextGroundCheckTime)
        {
            isGrounded = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffSet, groundMask);
            nextGroundCheckTime = Time.time + groundCheckInterval;
        }
    }

    void Awake()
    {
        Instance = this;
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction, bool isJumpButtonPress)
    {
        if (!canMove) return;
        
        if(isJumpButtonPress & isGrounded)
            Jump();
        
        if(Mathf.Abs(direction) > 0.01f)
        {
            PlayerRotation(direction);
            HorizontalMovement(direction);
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void HorizontalMovement(float direction)
    {
        if(isGrounded)
            rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);    
    }
    

    private void PlayerRotation(float direction)
    {
        playerRotation.flipX = direction < 0;
        firePoint.localPosition = new Vector2(direction > 0 ? 0.1f : -0.1f, firePoint.localPosition.y);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
