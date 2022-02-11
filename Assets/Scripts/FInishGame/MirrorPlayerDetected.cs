using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayerDetected : MonoBehaviour
{
    public static bool isMirrorPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isMirrorPlayer = collision.gameObject.GetComponent<MirrorPlayer>();
    }

}
