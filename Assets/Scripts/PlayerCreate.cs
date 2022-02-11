using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WORNING: Temporary solutions
/// </summary>
public class PlayerCreate
{
    private static bool isMoveStop = true;

    public void StartAnimation(Vector2 movePoint, Animator animationController, Rigidbody2D moveObject)
    {
        isMoveStop = false;

        Transform Player = animationController.gameObject.transform;

        Vector2 startPosition = Player.position;
        Vector3 finishPosition = Vector3.zero;
        Debug.Log(Player.localPosition);
        if (movePoint.x > 50 && movePoint.x <= 100)
        {
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right;
            finishPosition = Vector3.right;

            animationController.SetBool("Right", true);

            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);
        }
        if (movePoint.x < -50 && movePoint.x >= -100)
        {
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left;
            finishPosition = Vector3.left;

            animationController.SetBool("Left", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);
        }
        if (movePoint.y > 50 && movePoint.y <= 100)
        {
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up;
            finishPosition = Vector3.up;

            animationController.SetBool("Up", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Down", false);
        }
        if (movePoint.y < -50 && movePoint.y >= -100)
        {
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down;
            finishPosition = Vector3.down;

            animationController.SetBool("Down", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
        }
        if (Player.localPosition.x >= 1f || Player.localPosition.x <= -1f)
        {
            moveObject.GetComponent<Rigidbody2D>().MovePosition(moveObject.transform.position + finishPosition);
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            animationController.SetBool("Down", false);
            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
        }
        if (Player.localPosition.y >= 1f || Player.localPosition.y <= -1f)
        {
            moveObject.GetComponent<Rigidbody2D>().MovePosition(moveObject.transform.position + finishPosition);
            animationController.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            animationController.SetBool("Down", false);
            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
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
