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
            Player.animator.Play("Kiss");
            MirrorPlayer.animator.Play("Kiss");
            GameManager.LevelStart.Invoke(1);
            PlayerMoving.isStartGame = false;
        }
    }
}
