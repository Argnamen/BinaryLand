using UnityEngine;

public class Rake : MonoBehaviour
{
    private bool isInstantiate = false;
    [SerializeField] private GameObject Projectile;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() || collision.GetComponent<MirrorPlayer>())
            Damage();

    }
    private void Damage()
    {
        this.gameObject.GetComponent<Animator>().Play("Rake");
        if (!isInstantiate)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            Instantiate(Projectile, this.transform);
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            isInstantiate = true;
        }
    }
}
