using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMng : MonoBehaviour
{
    public static int maxEnemy;
    [SerializeField] private int maxenemy;

    public static int currentEnemy;   
    [SerializeField] private TextMeshProUGUI textCountEn;

    void Start()
    {
        currentEnemy = 0;      
        maxEnemy = maxenemy;
    }
    private void Update()
    {
        textCountEn.text = currentEnemy.ToString();
    }


}
