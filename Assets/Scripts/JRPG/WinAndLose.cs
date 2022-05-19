using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    public void Win()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(1);
    }

    public void Lose()
    {
        SceneManager.LoadScene(2);
    }
}
