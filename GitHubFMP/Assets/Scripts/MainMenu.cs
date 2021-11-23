using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial Level");
    }


    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quitting()
    {
        Application.Quit();
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void FinalLevel()
    {
        SceneManager.LoadScene("FinalLevel");
    }
    
}
