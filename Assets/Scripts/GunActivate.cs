using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunActivate : MonoBehaviour
{
    private IEnumerator SpriteActivate()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<BonusScore>())
        {
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<SpriteRenderer>().enabled = true;
            UINumbersControl.scoreAction.Invoke(100);

            StartCoroutine(SpriteActivate());
            return;
        }
        if (collision.GetComponent<Mob>())
        {
            Destroy(collision.gameObject);
            UINumbersControl.scoreAction.Invoke(50);
            return;
        }
    }
}
