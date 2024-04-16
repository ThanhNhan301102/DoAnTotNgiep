using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    
    private bool flag = false;

    [SerializeField] private SpriteRenderer sprEnemy;
    private Color colorHit, colorUnHit;

    private float timeChangeColor, timer;
    [SerializeField] private Color colorDeath;
    [SerializeField] private List<GameObject> deaths;

    [SerializeField] private EnCount enCount;

    private void Start()
    {
        colorHit = new Color32(174, 86, 86, 255);
        colorUnHit = sprEnemy.color;
        timer = -1.0f;
        timeChangeColor = 0.2f;
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
        if (health <= 0)
        {
            //flag = true;
            Destroy(gameObject);
            Death();
            GameMng.currentEnemy++;
            //countEn.UpdateText(GameMng.currentEnemy);
        }
            
    }

    void Death()
    {
        int index = Random.Range(0, deaths.Count);
        GameObject obj = Instantiate(deaths[index], transform.position, Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().color = colorDeath;
    }

}
