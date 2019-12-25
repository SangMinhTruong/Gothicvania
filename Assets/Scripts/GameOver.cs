using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    //Quit button
    public GameObject pauseMenu;
   public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        Projectorie.damage = 25;
        ProjectorieLeft.damage = 25;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void MainMenu()
    {
        Projectorie.damage = 25;
        ProjectorieLeft.damage = 25;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause()
    {
        Time.timeScale=0;
        pauseMenu.SetActive(true);
    }
    //public void About()
    //{
        
    //}
    public void Return()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
