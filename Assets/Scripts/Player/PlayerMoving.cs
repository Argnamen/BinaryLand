using System.Collections;
using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public static float[,] LevelMap;

    public static bool isStartGame = false;

    public static bool
        isFlight = false,
        isGod = false,
        isSpeed = false;

    private float Timer = 1f;
    public void FLightEffect()
    {
        Timer -= Time.fixedDeltaTime;
        if (Timer <= 0)
        {
            isFlight = false;
            Timer = 1;
        }
    }

    public void GodEffect(GameObject player)
    {
        if (player.TryGetComponent<BoxCollider2D>(out var dis))
            dis.enabled = false;
        Timer -= Time.fixedDeltaTime;
        if (Timer <= 0)
        {
            isGod = false;
            Timer = 1;
            if (player.TryGetComponent<BoxCollider2D>(out var en))
                en.enabled = true;
        }
    }

    public void SpeedEffect(GameObject player)
    {
        Timer -= Time.fixedDeltaTime;
        JoystickControl.Speed = 2;
        if (Timer <= 0)
        {
            JoystickControl.Speed = 1;
            isSpeed = false;
            Timer = 1f;
        }
    }

    public Vector3 Move(Vector2 movePoint, Animator animationController, float speed)
    {

        Vector3 moveVector = Vector3.zero;

        GameObject player = animationController.gameObject;

        LevelMap = SceneLoader.navigationMap;

        if ((LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 2) && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if ((LevelMap[(int)player.transform.position.x, (int)player.transform.position.y - 1] == 2) && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if (LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 2 && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if (LevelMap[(int)player.transform.position.x, (int)player.transform.position.y + 1] == 2 && player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = true;
        else if (player.GetComponent<MirrorPlayer>())
            MirrorPlayer.IsFinishGame = false;

        if (LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y] == 2 && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if (LevelMap[(int)player.transform.position.x, (int)player.transform.position.y + 1] == 2 && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if ((LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y] == 2) && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if ((LevelMap[(int)player.transform.position.x, (int)player.transform.position.y - 1] == 2) && player.GetComponent<Player>())
            Player.IsFinishGame = true;
        else if (player.GetComponent<Player>())
            Player.IsFinishGame = false;

        if (Player.IsFinishGame && MirrorPlayer.IsFinishGame)
        {
            moveVector = Vector3.zero;
        }
        if (isStartGame)
        {
            try
            {
                int right = (int)LevelMap[(int)player.transform.position.x + 1, (int)player.transform.position.y];
                int left = (int)LevelMap[(int)player.transform.position.x - 1, (int)player.transform.position.y];
                int up = (int)LevelMap[(int)player.transform.position.x, (int)player.transform.position.y + 1];
                int down = (int)LevelMap[(int)player.transform.position.x, (int)player.transform.position.y - 1];

                if (isGod)
                    GodEffect(player);

                if (isSpeed)
                    SpeedEffect(player);

                if (movePoint.x > 71 && movePoint.x <= 100)
                {
                    animationController.Play("Right");

                    if ((right == 0 || right >= 2) && !isFlight)
                    {
                        moveVector = Vector3.right;
                    }
                    else if (isFlight)
                    {
                        moveVector = Vector3.right;
                        FLightEffect();
                    }
                }
                if (movePoint.x < -71 && movePoint.x >= -100)
                {
                    animationController.Play("Left");


                    if ((left == 0 || left >= 2) && !isFlight)
                    {
                        moveVector = Vector3.left;
                    }
                    else if (isFlight)
                    {
                        moveVector = Vector3.left;
                        FLightEffect();
                    }
                }
                if (movePoint.y > 71 && movePoint.y <= 100)
                {
                    animationController.Play("Up");


                    if ((up == 0 || up >= 2) && !isFlight)
                    {
                        moveVector = Vector3.up;
                    }
                    else if (isFlight)
                    {
                        moveVector = Vector3.up;
                        FLightEffect();
                    }
                }
                if (movePoint.y < -71 && movePoint.y >= -100)
                {
                    animationController.Play("Down");

                    if ((down == 0 || down >= 2) && !isFlight)
                    {
                        moveVector = Vector3.down;
                    }
                    else if (isFlight)
                    {
                        moveVector = Vector3.down;
                        FLightEffect();
                    }
                }

                if (movePoint == Vector2.zero)
                {
                    animationController.Play("Idle");
                    moveVector = Vector3.zero;
                }
            }

            catch
            {
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
