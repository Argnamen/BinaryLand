using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(32);
    }

    public void Continue()
    {
        SceneManager.LoadScene(32);
    }
}
