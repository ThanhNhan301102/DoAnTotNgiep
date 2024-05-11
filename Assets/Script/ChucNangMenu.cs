using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChucNangMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    public static bool click = true;    //check dieu kien de thuc hien lenh ban sung

    public void pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0; //cac hoat dong cua game se dug lai (dong bang thoi gian)                
        click = false;   
    }
    public void home()
    {
        click = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void comtinue()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        click = true;
    }
    public void restart()
    {
        Time.timeScale = 1;
        click = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //load lai level nay
    }
}
