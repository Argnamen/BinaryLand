using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private PlayerMoving playerMove;

    public static bool IsFinishGame;

    Vector3 newMoveVector;

    public static Animator animator;

    public static bool isInvertMoveY = false, isInvertMoveX = false;

    public static bool GodMod = false;

    [SerializeField] private Camera PlayerCamera;

    private void Move(Vector2 movePoint, float speed)
    {
        if (!GodMod)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (isInvertMoveY)
            if (movePoint.y != 0)
                movePoint = new Vector2(movePoint.x, -movePoint.y);
        if (isInvertMoveX)
            if (movePoint.x != 0)
                movePoint = new Vector2(-movePoint.x, movePoint.y);

        Vector3 playerFloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
            this.transform.position.z);

        if (this.transform.position == playerFloorPoint)
            newMoveVector = playerMove.Move(movePoint, this.GetComponent<Animator>(), speed);



        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            this.transform.position + newMoveVector,
            speed / 32);

    }

    private void OnEnable()
    {
        animator = this.gameObject.GetComponent<Animator>();
        playerMove = new PlayerMoving();

        animator.Play("Idle");

        EventList.MovePlayer += Move;
    }

    private void OnDestroy()
    {
        EventList.MovePlayer -= Move;
    }
}
