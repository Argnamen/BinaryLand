using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    private void EndGame(int time)
    {
        if (time <= 0)
            LoadScene(0);
    }

    private void NextLevel(int round)
    {
        try
        {
            LoadScene(round);
        }
        catch
        {
            LoadScene(0);
        }
    }

    private void Awake()
    {
        UINumbersControl.timeAction += EndGame;
        UINumbersControl.roundAction += NextLevel;
    }
}
