using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{
    public List<GameObject> enemies;
    [SerializeField] private float timestart;
    [SerializeField] private float timeend;
    [SerializeField] private int maxCount;  //so lan khoi tao enemy
    private int count;
    void Start()
    {
        count = 0;
        InvokeRepeating("RandomEnemy", 30, Random.Range(timestart, timeend));
    }

    private void Update()
    {
        if (count == maxCount)
            CancelInvoke("RandomEnemy");
    }

    void RandomEnemy()
    {
        count++;
        int e = Random.Range(0, enemies.Count);
        GameObject newEnemy = Instantiate(enemies[e], transform.position, Quaternion.identity);
    }
}
