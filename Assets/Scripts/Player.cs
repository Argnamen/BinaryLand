using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform GunRotate;
    private PlayerCreate playerCreate = new PlayerCreate();

    public static UnityAction<Vector2, int> moveAction;
    public static UnityAction<int> scoreAction;

    private void Move(Vector2 movePoint, int speed)
    {
        this.GetComponent<Rigidbody2D>().velocity = movePoint.normalized * speed;

        playerCreate.StartAnimation(movePoint, this.GetComponent<Animator>());
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
