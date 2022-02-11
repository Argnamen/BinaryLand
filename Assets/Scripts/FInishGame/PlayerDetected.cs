using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    public static bool isPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayer = collision.gameObject.GetComponent<Player>();
    }
}
