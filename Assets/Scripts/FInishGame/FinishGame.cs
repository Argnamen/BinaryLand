using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void Update()
    {
        if (Player.IsFinishGame && MirrorPlayer.IsFinishGame)
        {
            PlayerMoving.isStartGame = false;
            GameManager.LevelStart.Invoke(1);
        }
    }
}
