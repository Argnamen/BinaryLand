using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private GameObject Web;

    [SerializeField] private float Heals = 1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {

            this.GetComponent<Animator>().Play("Death");
            UINumbersControl.scoreAction.Invoke(100);

            Destroy(collision.gameObject);
        }


        else if (collision.TryGetComponent<Water>(out var i))
        {
            if (i.isPlayer == true)
            {
                if (Heals <= 0.5)
                {
                    this.GetComponent<Animator>().Play("Death");
                    UINumbersControl.scoreAction.Invoke(100);
                }
                else
                {
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    --Heals;
                }
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
