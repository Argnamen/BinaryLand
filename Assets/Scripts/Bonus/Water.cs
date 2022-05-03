using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isPlayer = false;

    public bool isDestroy = false;

    private void FixedUpdate()
    {
        if (isDestroy)
            Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MirrorPlayer>() || collision.GetComponent<Player>())
        {
            this.GetComponent<Animator>().Play("Splash");
            this.GetComponent<BoxCollider2D>().size = new Vector2(2.2f, 2.2f);
            isPlayer = true;
        }
    }
}
