using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMap : MonoBehaviour
{
    private bool isOpen = false;
    [SerializeField] private GameObject iconLock;
    [SerializeField] private GameObject settingScreen;
    [SerializeField] private GameObject instructionScreen;

    private void Update()
    {
        if (GameMng.isWin == true && isOpen == false)
        {
            isOpen = true;
            iconLock.SetActive(false);
        }
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        if (GameMng.isWin == true)
            SceneManager.LoadScene(2);
    }
    public void quit(){
        Application.Quit();
    }
    public void setting()
    {
        settingScreen.SetActive(true);
    }
    public void instruction()
    {
        instructionScreen.SetActive(true);
    }
    public void exit()
    {
        settingScreen.SetActive(false);
        instructionScreen.SetActive(false);
    }
}
