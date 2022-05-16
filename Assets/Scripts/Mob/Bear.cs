using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{

    private int Heals = 1;

    public bool isDeath = false;

    private void Update()
    {
        if (isDeath)
            Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
            if (Heals == 1)
            {
                this.GetComponent<Animator>().Play("Death");
                UINumbersControl.scoreAction.Invoke(200);
            }
            else
            {
                --Heals;
            }
        }

        if (collision.TryGetComponent<Water>(out var i))
            if (i.isPlayer == true)
            {
                if (Heals == 1)
                {
                    this.GetComponent<Animator>().Play("Death");
                    UINumbersControl.scoreAction.Invoke(200);
                }
                else
                {
                    --Heals;
                }
            }
        if ((collision.GetComponent<Player>() || collision.GetComponent<MirrorPlayer>()) && PlayerMoving.isStartGame)
        {
            collision.GetComponent<Animator>().Play("Fail");
            EventList.LevelStart.Invoke(-1);
            PlayerMoving.isStartGame = false;
        }
    }
}
