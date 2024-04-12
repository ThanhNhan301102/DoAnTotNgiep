using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private float time = 2f;
    private float timer;

    private void Start()
    {
        currentHealth = 0;
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
    public void Hit(int damage)
    {
        if (currentHealth > 0 && timer <= 0)
        {
            currentHealth -= damage;
            timer = time;
        }

            
    }
    public void AddHealth(int val)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += val;
        }
    }
}
