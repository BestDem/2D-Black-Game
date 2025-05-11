using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sp;

    private Rigidbody2D rb;

    private const float IDEL_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERD_STATE = 2;

    private float currentState, currentTimeToRevert;

    void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERD_STATE;
        }
        
        switch(currentState)           //проверка на текущее состояние
        {
            case IDEL_STATE:
            currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
            rb.velocity = Vector2.left * speed;
                break;
            case REVERD_STATE:
                sp.flipX = !sp.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                break;
        }
        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyStopper"))
            currentState = IDEL_STATE;
    }
}
