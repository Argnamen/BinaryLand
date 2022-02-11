using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayer : MonoBehaviour
{
    [SerializeField] private Transform GunRotate;
    [SerializeField] private Rigidbody2D MoveVelocity;

    private PlayerCreate playerCreate = new PlayerCreate();

    private bool isMoveStop = true;

    
    private void Move(Vector2 movePoint, int speed)
    {
        if (movePoint.x != 0)
            movePoint = new Vector2(-movePoint.x, movePoint.y);
        playerCreate.StartAnimation(movePoint, this.GetComponent<Animator>());
    }

    private void Awake()
    {
        Player.moveAction += Move;
    }

    private void OnDestroy()
    {
        Player.moveAction -= Move;
    }
}
