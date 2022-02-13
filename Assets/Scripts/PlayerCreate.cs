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

        Vector3 playerFloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(player.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(player.transform.position.y).ToString()),
            player.transform.position.z);

        Vector3 playerCeilingPoint = new Vector3(
            Int32.Parse(Mathf.CeilToInt(player.transform.position.x).ToString()),
            Int32.Parse(Mathf.CeilToInt(player.transform.position.y).ToString()),
            player.transform.position.z);

        if (player.transform.position.x != Mathf.Clamp(player.transform.position.x, playerCeilingPoint.x - 0.1f, playerCeilingPoint.x) &&
            player.GetComponent<Rigidbody2D>().velocity == Vector2.right)
            return;

        if (player.transform.position.y != Mathf.Clamp(player.transform.position.y, playerCeilingPoint.y - 0.1f, playerCeilingPoint.y) &&
            player.GetComponent<Rigidbody2D>().velocity == Vector2.up)
            return;

        if (player.transform.position.x != Mathf.Clamp(player.transform.position.x, playerFloorPoint.x, playerFloorPoint.x + 0.1f) &&
           player.GetComponent<Rigidbody2D>().velocity == Vector2.left)
            return;

        if (player.transform.position.y != Mathf.Clamp(player.transform.position.y, playerFloorPoint.y, playerFloorPoint.y + 0.1f) &&
           player.GetComponent<Rigidbody2D>().velocity == Vector2.down)
            return;

        if (movePoint == Vector2.zero &&
            (animationController.GetBool("Right")
            || animationController.GetBool("Up")))
        {
            player.GetComponent<Rigidbody2D>().MovePosition(playerCeilingPoint);

        }

        if (movePoint == Vector2.zero &&
            (animationController.GetBool("Left")
            || animationController.GetBool("Down")))
        {
            player.GetComponent<Rigidbody2D>().MovePosition(playerFloorPoint);
        }


        if (movePoint.x > 50 && movePoint.x <= 100)
        {
           
            player.GetComponent<Rigidbody2D>().velocity = Vector2.right;

            animationController.SetBool("Right", true);


            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);

            isMoveStop = false;

            return;
        }
        if (movePoint.x < -50 && movePoint.x >= -100)
        {
            
            player.GetComponent<Rigidbody2D>().velocity = Vector2.left;

            animationController.SetBool("Left", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Up", false);
            animationController.SetBool("Down", false);

            isMoveStop = false;

            return;
        }
        if (movePoint.y > 50 && movePoint.y <= 100)
        {
            
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up;

            animationController.SetBool("Up", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Down", false);

            isMoveStop = false;

            return;
        }
        if (movePoint.y < -50 && movePoint.y >= -100) 
        {
            
            player.GetComponent<Rigidbody2D>().velocity = Vector2.down;

            animationController.SetBool("Down", true);

            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Up", false);

            isMoveStop = false;

            return;
        } 

        if(movePoint == Vector2.zero)
        {

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            animationController.SetBool("Up", false);
            animationController.SetBool("Right", false);
            animationController.SetBool("Left", false);
            animationController.SetBool("Down", false);
        }

    }

    
}
