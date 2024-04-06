using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    private float time = 2f;
    private float timer;

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
    public void Hit(int damage)
    {
        if (health > 0 && timer <= 0)
        {
            health -= damage;
            timer = time;
        }

            
    }
}
