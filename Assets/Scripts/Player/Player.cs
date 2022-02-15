using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private PlayerMoving playerMove;

    public static bool IsFinishGame;

    Vector3 newMoveVector;

    private void Move(Vector2 movePoint, float speed)
    {

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

    private void Awake()
    {
        playerMove = new PlayerMoving();
        GameManager.MovePlayer += Move;
    }

    private void OnDestroy()
    {
        GameManager.MovePlayer -= Move;
    }
}
