using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private GameObject canvas;
    //[SerializeField] private TextMeshProUGUI textMP1;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.down * 0.7f, transform.right, 1.5f, LayerMask.GetMask("Player"));
        if(hit.collider != null)
        {
            canvas.SetActive(true);
            //textMP1.enabled = true;
        }
        else
        {
            canvas.SetActive(false);
        }
           
    }

}
