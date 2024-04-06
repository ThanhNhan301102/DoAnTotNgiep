using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator animator;

    private bool isRight = true;
    [SerializeField] private float enemySpeed;
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer enemySpr;
    Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (player != null && transform.position != player.position)
        {
            direction = (player.position - transform.position).normalized;
            Vector3 pos = transform.position + direction * enemySpeed * Time.deltaTime;
            rb.MovePosition(pos);
        }
        FlipNV();
    }
    void Flip()
    {
        isRight = !isRight;
        enemySpr.flipX = !enemySpr.flipX;
    }
    void FlipNV()
    {
        if (direction.x < 0 && isRight)
        {
            Flip();
        }
        else if (direction.x > 0 && !isRight)
        {
            Flip();
        }
    }
}
