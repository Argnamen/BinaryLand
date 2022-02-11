using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// WORNING: Temporary solutions
/// </summary>
public class PlayerCreate
{
    private bool isMoveStop = true;

    public void StartAnimation(Vector2 movePoint, Animator animationController)
    {
        GameObject player = animationController.gameObject;

        Vector3Int playerStartPoint = new Vector3Int(
                (int)Math.Floor(player.transform.position.x + 0.1f),
                (int)Math.Floor(player.transform.position.y + 0.1f),
                (int)player.transform.position.z);

        Vector3Int playerFinishPoint = new Vector3Int(
            (int)Math.Ceiling(player.transform.position.x),
            (int)Math.Ceiling(player.transform.position.y),
            (int)player.transform.position.z);

        Debug.Log(playerStartPoint);
        Debug.Log(playerFinishPoint);
        if (isMoveStop)
        {
            isMoveStop = false;

            if (movePoint.x > 50 && movePoint.x <= 100)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector2.right;

                animationController.SetBool("Right", true);

                animationController.SetBool("Left", false);
                animationController.SetBool("Up", false);
                animationController.SetBool("Down", false);

                return;
            }
            if (movePoint.x < -50 && movePoint.x >= -100)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector2.left;

                animationController.SetBool("Left", true);

                animationController.SetBool("Right", false);
                animationController.SetBool("Up", false);
                animationController.SetBool("Down", false);

                return;
            }
            if (movePoint.y > 50 && movePoint.y <= 100)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector2.up;

                animationController.SetBool("Up", true);

                animationController.SetBool("Right", false);
                animationController.SetBool("Left", false);
                animationController.SetBool("Down", false);

                return;
            }
            if (movePoint.y < -50 && movePoint.y >= -100)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector2.down;

                animationController.SetBool("Down", true);

                animationController.SetBool("Right", false);
                animationController.SetBool("Left", false);
                animationController.SetBool("Up", false);

                return;
            }
            if (movePoint == Vector2.zero)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.transform.position = playerStartPoint;
                player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(playerStartPoint.x, playerStartPoint.y));

                animationController.SetBool("Down", false);
                animationController.SetBool("Right", false);
                animationController.SetBool("Left", false);
                animationController.SetBool("Up", false);
            }

        }

        if (playerStartPoint == playerFinishPoint)
        {
            player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(playerStartPoint.x, playerStartPoint.y));
            isMoveStop = true;
        }

        if (player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(playerStartPoint.x, playerStartPoint.y));
            isMoveStop = true;
        }

    }

    public void UpdateGunRotate(Vector2 movePoint)
    {
        Quaternion Up = new Quaternion(0f, 0f, 0f, 0f);
        Quaternion Down = new Quaternion(0f, 0f, 180f, 0f);
        Quaternion Rigth = new Quaternion(0f, 0f, -90f, 0f);
        Quaternion Left = new Quaternion(0f, 0f, 90f, 0f);
    }
}
