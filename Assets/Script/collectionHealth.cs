using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectionHealth : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if(player != null)
        {
            if(player.currentHealth < player.maxHealth)
            {
                
                player.AddHealth(1);
                Destroy(gameObject);
            }          
        }
    }
}
