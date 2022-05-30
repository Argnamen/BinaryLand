using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{

    [SerializeField] private int Heals = 1;

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
                if (Heals <= 0.5)
                {
                    this.GetComponent<Animator>().Play("Death");
                    UINumbersControl.scoreAction.Invoke(200);
                }
                else
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    --Heals;
                }
            }
        if ((collision.GetComponent<Player>() || collision.GetComponent<MirrorPlayer>()) && PlayerMoving.isStartGame)
        {
            collision.GetComponent<Animator>().Play("Fail");
            if (EventList.LevelStart != null)
            {
                EventList.LevelStart.Invoke(-1);
                PlayerMoving.isStartGame = false;
            }
        }
    }
}
