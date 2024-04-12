using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playrSpeed = 5f;

    private Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    private bool isRight = true; //nv huong ve phia ben phai

    private float rollBoost = 3f;   //cong vao speed
    private float rollTime = 0.5f; //tg quay 1 vong
    private float rollTimer = 0f;
    private bool rollOnce = false;

    public Animator animator;

    public SpriteRenderer spr;
    private enum MovementState { ide, walk, roll}

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && rollTimer <= 0)
        {
            animator.SetBool("roll", true);
            playrSpeed += rollBoost;
            rollTimer = rollTime;
            rollOnce = true;
        }
        if(rollTimer <= 0 && rollOnce == true)
        {
            animator.SetBool("roll", false);
            rollOnce = false;
            playrSpeed -= rollBoost;
        }
        else
        {
            rollTimer -= Time.deltaTime;
        }
        FlipNV();
        UpdateAnimation();
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = rb.position;
        pos.x += horizontal * playrSpeed * Time.deltaTime;
        pos.y += vertical * playrSpeed * Time.deltaTime;
        rb.MovePosition(pos);

    }

    void Flip()
    {
        isRight = !isRight;
        spr.flipX = !spr.flipX;
    }

    void FlipNV()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x && isRight)
            Flip();
        else if (mousePos.x > transform.position.x && !isRight)
            Flip();
    }
    
    private void UpdateAnimation()
    {
        MovementState state;
        
        if (horizontal != 0)
        {
            state = MovementState.walk;
        }
        else if(vertical != 0)
            state = MovementState.walk;
        else
            state = MovementState.ide;
        animator.SetInteger("state", (int)state);
    }
}
