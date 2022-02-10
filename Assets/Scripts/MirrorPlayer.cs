using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayer : MonoBehaviour
{
    [SerializeField] private Transform GunRotate;

    private PlayerCreate playerCreate = new PlayerCreate();
    private void Move(Vector2 movePoint, int speed)
    {
        movePoint = movePoint.normalized;
        if (movePoint.x != 0)
            movePoint = new Vector2(-movePoint.x, movePoint.y);
        this.GetComponent<Rigidbody2D>().velocity = movePoint * speed;
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
