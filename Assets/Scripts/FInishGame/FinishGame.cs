using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Player.IsFinishGame && MirrorPlayer.IsFinishGame)
        {
            Player.IsFinishGame = false;
            MirrorPlayer.IsFinishGame = false;

            if (Player.isInvertMoveY || MirrorPlayer.isInvertMoveY)
            {
                Player.animator.Play("Kiss2");
                MirrorPlayer.animator.Play("Kiss2");
            }
            else if (Player.isInvertMoveX || MirrorPlayer.isInvertMoveX)
            {
                Player.animator.Play("Kiss");
                MirrorPlayer.animator.Play("Kiss");
            }

            PlayerMoving.isFlight = false;
            PlayerMoving.isGod = false;
            PlayerMoving.isSpeed = false;

            if(EventList.LevelStart != null)
                EventList.LevelStart.Invoke(1);

            Player.isInvertMoveY = false;
            Player.isInvertMoveX = false;

            MirrorPlayer.isInvertMoveY = false;
            MirrorPlayer.isInvertMoveX = false;

            PlayerMoving.isStartGame = false;

            return;
        }
    }
}
