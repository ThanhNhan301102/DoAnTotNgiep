using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    public static int maxEnemy;
    [SerializeField] private int maxenemy;

    public static int currentEnemy;   
    [SerializeField] private TextMeshProUGUI textCountEn;

    [SerializeField] private AudioSource auBackGround;

    public static int display;   //kiem tra game ket thuc chua: 0 chua, 1 thang, 2 thua
    [SerializeField] private TextMeshProUGUI victory;
    [SerializeField] private TextMeshProUGUI defeat;
    [SerializeField] private GameObject panel;  
    private bool isEndGame = false;

    void Start()
    {
        display = 0;
        currentEnemy = 0;      
        maxEnemy = maxenemy;
        auBackGround.Play();
    }
    private void Update()
    {
        textCountEn.text = currentEnemy.ToString() + " / " + maxEnemy.ToString();
        if(currentEnemy == maxenemy)
        {       
            display = 1;
        }
        if (display != 0 && isEndGame == false)
            Invoke("EndGame", 1.5f);
    }

    private void EndGame()
    {     
        panel.SetActive(true);
        if (display == 1)
        {
            victory.enabled = true;
        }
        else
            defeat.enabled = true;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Collider2D>().enabled = false;
        isEndGame = true;
        Invoke("home", 5.0f);
    }

    void home()
    {
        SceneManager.LoadScene(0);
    }
}
