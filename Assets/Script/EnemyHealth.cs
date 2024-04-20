using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private int currentHealth;
    
    //private bool flag = false;

    [SerializeField] private SpriteRenderer sprEnemy;

    private Color colorHit, colorUnHit;
    private float timeChangeColor, timer;   //doi mau khi nhan sat thuong
    [SerializeField] private Color colorDeath;
    [SerializeField] private List<GameObject> deaths;

    private HealthBarEn healthBarEn;


    private void Start()
    {
        colorHit = new Color32(174, 86, 86, 255);
        colorUnHit = sprEnemy.color;
        timer = -1.0f;
        timeChangeColor = 0.2f;

        currentHealth = health;
        healthBarEn = GetComponent<HealthBarEn>();
        healthBarEn.UpdateHealthBarEn(currentHealth, health);
    }

    private void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;
        else
            sprEnemy.color = colorUnHit;
    }
    public void Hit(int damage) //khi sat thuong
    {
        timer = timeChangeColor;
        sprEnemy.color = colorHit;
        currentHealth -= damage;
        healthBarEn.UpdateHealthBarEn(currentHealth, health);   //cap nhat thanh mau

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Death();
            GameMng.currentEnemy++;         
        }
            
    }

    void Death()    //khoi tao cac hat sau khi destroy enemy
    {
        int index = Random.Range(0, deaths.Count);
        GameObject obj = Instantiate(deaths[index], transform.position, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().color = colorDeath;
    }

}
