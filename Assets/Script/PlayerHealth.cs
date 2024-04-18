using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;   
    private float time = 2f;
    private float timer;

    [SerializeField] private SpriteRenderer sprPlayer;
    private Color colorHit, colorUnHit;

    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateFillBar(currentHealth, maxHealth);

        colorUnHit = sprPlayer.color;
        colorHit = new Color32(174, 86, 86, 255);
    }
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
    public void Hit(int damage)
    {
        sprPlayer.color = colorHit;
        if (currentHealth > 0 && timer <= 0)
        {
            currentHealth -= damage;
            healthBar.UpdateFillBar(currentHealth, maxHealth);
            timer = time;
        }           
    }

    public void UnHit()
    {
        sprPlayer.color = colorUnHit;
    }
    public void AddHealth(int val)
    {       
        currentHealth += val;
        healthBar.UpdateFillBar(currentHealth, maxHealth);
    }
}
