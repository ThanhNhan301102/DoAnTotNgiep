using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    [SerializeField] private SpriteRenderer spr;

    [SerializeField] private float speedRobot;
    private Vector3 direction;  //huong di
    private Vector3 exit;   //loi ra
    private bool isRight = true;

    private bool flag1 = false, flag2 = true, flag3 = false;
    
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI textMP1, textMP2, textMP3;
    [SerializeField] private GameObject exitPrefab;

    private enum MovementState { ide, walk};

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        exit = new Vector3(x, y, 0);
    }

    
    void Update()
    {
            
        if (GameMng.currentEnemy == GameMng.maxEnemy)
        {
            flag1 = true;
            textMP1.enabled = false;
        }
      
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.down * 0.7f, transform.right, 1.5f, LayerMask.GetMask("Player"));
        if(hit.collider != null)
        {
            display();
            if (flag1 == true && Input.GetKeyDown(KeyCode.X))
            {
                flag2 = false;
            }
        }
        else
        {
            canvas.SetActive(false);
        }
        


        if(flag2 == false && flag3 == false)
        {
            direction = (exit - transform.position).normalized;
            Vector3 pos = transform.position + direction * speedRobot * Time.deltaTime;
            rigidbody2D.MovePosition(pos);

            if (Vector3.Distance(transform.position, exit) < 0.1f) //chenh lech khoang cach < 0.1f
            {
                flag2 = true;
                flag3 = true;
                textMP2.enabled = false;
                GameObject obj = Instantiate(exitPrefab, exit, Quaternion.Euler(45f, 0f, 0f));
                direction = new Vector3(0, 0, 0);             
            }
        }

        UpdateAnimation();
    }

   

    void display()
    {
        if(flag1 == false)
        {           
            canvas.SetActive(true);
            textMP1.enabled = true;
        }
        else if(flag1 == true && flag3 == false)
        {          
            canvas.SetActive(true);
            textMP2.enabled = true;
        }
        else if(flag3 == true)
        {
            canvas.SetActive(true);
            textMP3.enabled = true;
        }
        
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
