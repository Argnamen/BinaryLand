using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    public static bool isPlayer;
    public static GameObject playerCollision;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayer = collision.gameObject.GetComponent<Player>();
        playerCollision = collision.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayer = collision.gameObject.GetComponent<Player>();
        playerCollision = collision.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayer = false;
    }
}
