using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{
    public List<GameObject> enemies;
    void Start()
    {
        InvokeRepeating("RandomEnemy", 2, Random.Range(10, 50));
    }

    void RandomEnemy()
    {
        int e = Random.Range(0, enemies.Count);
        GameObject newEnemy = Instantiate(enemies[e], transform.position, Quaternion.identity);
    }
}
