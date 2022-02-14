using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayerDetected : MonoBehaviour
{
    public static bool isMirrorPlayer;
    public static GameObject playerMirorCollision;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isMirrorPlayer = collision.gameObject.GetComponent<MirrorPlayer>();
        playerMirorCollision = collision.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isMirrorPlayer = collision.gameObject.GetComponent<MirrorPlayer>();
        playerMirorCollision = collision.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        isMirrorPlayer = false;
    }

}
