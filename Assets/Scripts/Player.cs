using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform GunRotate;
    [SerializeField] private Rigidbody2D MoveVelocity;

    private PlayerCreate playerCreate = new PlayerCreate();

    public static UnityAction<Vector2, int> moveAction;

    private bool isMoveStop = true;

    

    private void Move(Vector2 movePoint, int speed)
    {
        playerCreate.StartAnimation(movePoint, this.GetComponent<Animator>(), MoveVelocity);
    }

    private void Awake()
    {
        moveAction += Move;
    }

    private void OnDestroy()
    {
        moveAction -= Move;
    }
}
