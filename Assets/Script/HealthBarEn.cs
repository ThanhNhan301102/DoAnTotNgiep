using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarEn : MonoBehaviour
{
    [SerializeField] private Image fillBarEn;
    
    public void UpdateHealthBarEn(int currentHealth, int maxHealth)
    {
        fillBarEn.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
