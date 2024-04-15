using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public static int golds;
    [SerializeField] private int currentGold;

    public static int maxEnemy;
    [SerializeField] private int maxenemy;

    public static int currentEnemy;
    [SerializeField] private int crEnemy;   //so enemy da tieu giet

    void Start()
    {
        currentEnemy = 0;
        golds = 0;
        maxEnemy = maxenemy;
    }

    private void Update()
    {
        currentGold = golds;
        crEnemy = currentEnemy;
    }

}
