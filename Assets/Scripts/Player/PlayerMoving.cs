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

        LevelMap = SceneLoader.navigationMap;

        if ((LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 2) && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if (player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = false;

        if (LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 2 && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if (player.GetComponent<Player>())
            Player.IsFinishGame = false;

        if (Player.IsFinishGame && MirrorPlayer.IsFinishGame)
        {
            moveVector = Vector3.zero;
        }
        if (isStartGame)
        {
            int right = LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y];
            int left = LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y];
            int up = LevelMap[(int)player.transform.position.x, (int)player.transform.position.y + 1];
            int down = LevelMap[(int)player.transform.position.x, (int)player.transform.position.y - 1];

            if (LevelMap[(int)player.transform.position.x, (int)player.transform.position.y] == 3)
                GameManager.SingleDamage.Invoke(1);
            if (movePoint.x > 71 && movePoint.x <= 100)
            {
                animationController.Play("Right");

                if (right == 0 || right >= 2)
                    moveVector = Vector3.right;
            }
            if (movePoint.x < -71 && movePoint.x >= -100)
            {
                animationController.Play("Left");


                if (left == 0 || left >= 2)
                    moveVector = Vector3.left;
            }
            if (movePoint.y > 71 && movePoint.y <= 100)
            {
                animationController.Play("Up");


                if (up == 0 || up >= 2)
                    moveVector = Vector3.up;
            }
            if (movePoint.y < -71 && movePoint.y >= -100)
            {
                animationController.Play("Down");

                if (down == 0 || down >= 2)
                    moveVector = Vector3.down;
            }

            if (movePoint == Vector2.zero)
            {
                animationController.Play("Idle");
                moveVector = Vector3.zero;
            }
        }
        else
        {
            moveVector = Vector3.zero;
        }

        return moveVector;
    }
}
