using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;   
    private float time = 2f;
    private float timer;

    [SerializeField] private SpriteRenderer sprPlayer;  //thay doi mau sac khi player bi sat thuong
    private Color colorHit, colorUnHit;

    [SerializeField] private HealthBar healthBar;

    public AudioSource touch;   //am thanh
    [SerializeField] private AudioSource auHit;

    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private List<GameObject> weapons;
    private bool isDeath = false;
    [SerializeField] private AudioSource auDeath;
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

        if(currentHealth == 0 && isDeath == false)
        {
            Death();
            
        }
    }

    void Death()    //player chet
    {
        GameMng.display = 2;
        auDeath.Play();
        isDeath = true;
        animatorPlayer.SetTrigger("death");
        for(int i=0; i<weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;  //nhan vat khong the di chuyen 
    }
    public void Hit(int damage)
    {
        sprPlayer.color = colorHit;
        if (currentHealth > 0 && timer <= 0)
        {
            auHit.Play();
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
        touch.Play();
        currentHealth += val;
        healthBar.UpdateFillBar(currentHealth, maxHealth);
    }
}
