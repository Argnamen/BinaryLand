using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(0);
    }
}
