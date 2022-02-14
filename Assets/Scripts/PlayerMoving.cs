using System.Collections;
using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public static int[,] LevelMap;

    public static bool isStartGame = true;
    public Vector3 Move(Vector2 movePoint, Animator animationController, float speed)
    {
        Vector3 moveVector = Vector3.zero;

        GameObject player = animationController.gameObject;



        LevelMap = SceneLoader.levelMap;

        if ((LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 2) && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if (player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = false;

        if (LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 2 && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if (player.GetComponent<Player>())
            Player.IsFinishGame = false;

        if (PlayerDetected.isPlayer && MirrorPlayerDetected.isMirrorPlayer)
        {
            animationController.Play("Idle");

            animationController.Play("Kiss");

            moveVector = Vector3.zero;
        }
        if (isStartGame)
        {
            Debug.Log(movePoint);
            if (movePoint.x > 71 && movePoint.x <= 100)
            {
                animationController.Play("Right");

                if (LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 0 ||
                    LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 2)
                    moveVector = Vector3.right;
            }
            if (movePoint.x < -71 && movePoint.x >= -100)
            {
                animationController.Play("Left");


                if (LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 0 ||
                    LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 2)
                    moveVector = Vector3.left;
            }
            if (movePoint.y > 71 && movePoint.y <= 100)
            {
                animationController.Play("Up");


                if (LevelMap[(int)player.transform.position.x, (int)player.transform.position.y + 1] == 0)
                    moveVector = Vector3.up;
            }
            if (movePoint.y < -71 && movePoint.y >= -100)
            {
                animationController.Play("Down");

                if (LevelMap[(int)player.transform.position.x, (int)player.transform.position.y - 1] == 0)
                    moveVector = Vector3.down;
            }

            if (movePoint == Vector2.zero)
            {
                animationController.Play("Idle");
            }

            return moveVector;
        }
        else
        {
            animationController.SetBool("Idle", true);

            animationController.SetBool("Up", false);
            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Down", false);

            animationController.SetBool("Kiss", true);

            return moveVector;
        }
    }
}
