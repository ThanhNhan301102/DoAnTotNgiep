using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject goldPrefab;
    private bool flag = false;

    [SerializeField] private SpriteRenderer sprEnemy;
    private Color colorHit, colorUnHit;

    private float timeChangeColor, timer;

    private void Start()
    {
        colorHit = new Color32(174, 86, 86, 255);
        colorUnHit = sprEnemy.color;
        timer = -1.0f;
        timeChangeColor = 0.1f;
    }

    private void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;
        else
            sprEnemy.color = colorUnHit;
    }
    public void Hit(int damage)
    {
        timer = timeChangeColor;
        sprEnemy.color = colorHit;
        health -= damage;
        if (health <= 0 && flag == false)
        {
            flag = true;
            Destroy(gameObject);
            GameObject newGold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            GameMng.currentEnemy++;
        }
            
    }

}
