using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameLoad(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Restart()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        GameManager.LevelStart.Invoke(-2);
    }
}
