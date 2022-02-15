using System.Collections;
using System;
using UnityEngine;

public class MirrorPlayer : MonoBehaviour
{
    private PlayerMoving playerMove;

    Vector3 newMoveVector, oldMoveVector;

    public static bool IsFinishGame;
    private void Move(Vector2 movePoint, float speed)
    {
        if (movePoint.x != 0)
            movePoint = new Vector2(-movePoint.x, movePoint.y);

        Vector3 playerFloorPoint = new Vector3(
            Int32.Parse(Mathf.FloorToInt(this.transform.position.x).ToString()),
            Int32.Parse(Mathf.FloorToInt(this.transform.position.y).ToString()),
            this.transform.position.z);

        if (this.transform.position == playerFloorPoint)
            newMoveVector = playerMove.Move(movePoint, this.GetComponent<Animator>(), speed);

        if (PlayerMoving.isStartGame == false)
            this.GetComponent<Animator>().Play("Kiss");

        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + newMoveVector, speed / 32);

        
    }

    private void Start()
    {
        playerMove = new PlayerMoving();
        GameManager.MovePlayer += Move;
    }

    private void OnDestroy()
    {
        GameManager.MovePlayer -= Move;
    }
}
