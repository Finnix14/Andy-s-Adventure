using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextlevel();
        }
    }

    public void LoadNextlevel()
    {
        SceneManager.LoadScene("Game");
    }
}
