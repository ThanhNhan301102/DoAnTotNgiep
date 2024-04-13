using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    [SerializeField] private SpriteRenderer spr;

    [SerializeField] private float speedRobot;
    private Vector3 direction;  //huong di
    private Transform exit;
    private bool isRight = true;
    private bool flag = false;

    private enum MovementState { ide, walk};

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        exit = GameObject.Find("Exit").transform;
    }

    
    void Update()
    {
        if(flag == false)
        {
            direction = (exit.position - transform.position).normalized;
            Vector3 pos = transform.position + direction * speedRobot * Time.deltaTime;
            rigidbody2D.MovePosition(pos);

            if (Vector3.Distance(transform.position, exit.position) < 0.1f) //chenh lech khoang cach < 0.1f
            {
                flag = true;
                direction = new Vector3(0, 0, 0);             
            }
        }
        
        UpdateAnimation();
    }

    void Flip()
    {
        isRight = !isRight;
        spr.flipX = !spr.flipX;
    }

    void UpdateAnimation()
    {
        MovementState state;
        if (direction.x != 0)
        {
            state = MovementState.walk;
            if (direction.x < 0 && isRight)
            {
                Flip();
            }
            else if (direction.x > 0 && !isRight)
            {
                Flip();
            }
        }
        else if (direction.y != 0)
        {
            state = MovementState.walk;
        }
        else
        {
            state = MovementState.ide;
        }

        animator.SetInteger("state", (int)state);
    }
}
