using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private GameObject Web;
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
                this.GetComponent<Animator>().Play("Death");
                UINumbersControl.scoreAction.Invoke(100);
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
