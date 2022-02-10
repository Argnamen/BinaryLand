using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WORNING: Temporary solutions
/// </summary>
public class PlayerCreate
{
    public void StartAnimation(Vector2 movePoint, Animator animationController)
    {
        if (movePoint.x > 50 && movePoint.x <= 100)
        {
            animationController.SetBool("Right", true);

            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);
            return;
        }
        if (movePoint.x < -50 && movePoint.x >= -100)
        {
            animationController.SetBool("Left", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);
            return;
        }
        if (movePoint.y > 50 && movePoint.y <= 100)
        {
            animationController.SetBool("Up", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Down", false);
            return;
        }
        if (movePoint.y < -50 && movePoint.y >= -100)
        {
            animationController.SetBool("Down", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
            return;
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
