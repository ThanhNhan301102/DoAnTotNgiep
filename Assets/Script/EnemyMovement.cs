using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float enemySpeed;
    
    private Transform player;

    [SerializeField] private SpriteRenderer enemySpr;
    private bool isRight = true;

    Vector3 direction;
    private Animator animator;

    private PlayerHealth e;
    [SerializeField] private int damageEnemy;

    private enum MovementState { ide, run, hit}

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        damageEnemy *= Setting.setEnemyDamage;

        GameObject target = GameObject.Find("Player");
        if(target != null)
        {
            player = target.transform;
        }
    }

    
    void Update()
    {
        
        if (player != null && transform.position != player.position)
        {
            direction = (player.position - transform.position).normalized;
            Vector3 pos = transform.position + direction * enemySpeed * Time.deltaTime;
            rigidbody2D.MovePosition(pos);
        }
        UpdateAnimation();

    }
    void Flip()
    {
        isRight = !isRight;
        enemySpr.flipX = !enemySpr.flipX;
    }
    void UpdateAnimation()
    {
        MovementState state;
        if (direction.x != 0)
        {
            state = MovementState.run;
            if (direction.x < 0 && isRight)
            {
                Flip();
            }
            else if(direction.x > 0 && !isRight)
            {
                Flip();
            }
        }
        else if(direction.y != 0)
        {
            state = MovementState.run;
        }
        else
        {
            state = MovementState.ide;
        }

        if (e != null)
        {
            state = MovementState.hit;
            e = null;
        }
            
        animator.SetInteger("state", (int)state);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        e = collision.GetComponent<PlayerHealth>();
        if (e != null)
        {
            e.Hit(damageEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e = collision.GetComponent<PlayerHealth>();
        if(e != null)
        {
            e.UnHit();
        }
    }
}
