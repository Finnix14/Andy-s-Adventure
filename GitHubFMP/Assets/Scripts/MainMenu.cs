using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
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
        SceneManager.LoadScene("LevelTwo");
    }

    
}
