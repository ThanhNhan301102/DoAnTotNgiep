using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public static int setEnemyHealth;
    public static int setEnemyDamage;
    public static int setPlayerHealth;
    public static int setWeaponDamage;
    [SerializeField] private TextMeshProUGUI txtSetEnemyHealth;
    [SerializeField] private TextMeshProUGUI txtSetEnemyDamage;
    [SerializeField] private TextMeshProUGUI txtSetPlayerHealth;
    [SerializeField] private TextMeshProUGUI txtSetWeaponDamage;

    void Start()
    {
        if (PlayerPrefs.HasKey("EnemyHealth"))  //neu ton tai
            setEnemyHealth = PlayerPrefs.GetInt("EnemyHealth");
        else
            setEnemyHealth = 1;

        if (PlayerPrefs.HasKey("EnemyDamage"))
            setEnemyDamage = PlayerPrefs.GetInt("EnemyDamage");
        else
            setEnemyDamage = 1;

        if (PlayerPrefs.HasKey("PlayerHealth"))
            setPlayerHealth = PlayerPrefs.GetInt("PlayerHealth");
        else
            setPlayerHealth = 1;

        if (PlayerPrefs.HasKey("WeaponDamage"))
            setWeaponDamage = PlayerPrefs.GetInt("WeaponDamage");
        else
            setWeaponDamage = 1;
    }
    
    void Update()
    {

        PlayerPrefs.SetInt("EnemyHealth", setEnemyHealth);  //luu tru gia tri vao PlayerPrefs
        PlayerPrefs.SetInt("EnemyDamage", setEnemyDamage);
        PlayerPrefs.SetInt("PlayerHealth", setPlayerHealth);
        PlayerPrefs.SetInt("WeaponDamage", setWeaponDamage);

        txtSetEnemyHealth.text = setEnemyHealth.ToString();
        txtSetEnemyDamage.text = setEnemyDamage.ToString();
        txtSetPlayerHealth.text = setPlayerHealth.ToString();
        txtSetWeaponDamage.text = setWeaponDamage.ToString();
    }

    public void minusEH()
    {
        if (setEnemyHealth > 1)
            setEnemyHealth -= 1;
    }
    public void plusEH()
    {
        if (setEnemyHealth < 5)
            setEnemyHealth += 1;
    }
    public void minusED()
    {
        if (setEnemyDamage > 1)
            setEnemyDamage -= 1;
    }
    public void plusED()
    {
        if (setEnemyDamage < 5)
            setEnemyDamage += 1;
    }
    public void minusPH()
    {
        if (setPlayerHealth > 1)
            setPlayerHealth -= 1;
    }

    public void plusPH()
    {
        if (setPlayerHealth < 5)
            setPlayerHealth += 1;
    }
    public void minusWD()
    {
        if (setWeaponDamage > 1)
            setWeaponDamage -= 1;
    }
    public void plusWD()
    {
        if (setWeaponDamage < 5)
            setWeaponDamage += 1;
    }
}
