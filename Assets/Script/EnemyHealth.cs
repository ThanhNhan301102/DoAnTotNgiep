using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject goldPrefab;
    private bool flag = false;

    public void Hit(int damage)
    {
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
