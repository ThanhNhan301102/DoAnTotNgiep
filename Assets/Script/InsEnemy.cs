using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{
    public List<GameObject> enemies;
    [SerializeField] private float timestart;
    [SerializeField] private float timeend;
    void Start()
    {
        InvokeRepeating("RandomEnemy", 5, Random.Range(timestart, timeend));
    }

    void RandomEnemy()
    {
        int e = Random.Range(0, enemies.Count);
        GameObject newEnemy = Instantiate(enemies[e], transform.position, Quaternion.identity);
    }
}
