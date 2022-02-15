using UnityEngine;

public class Rake : MonoBehaviour
{
    private bool isInstantiate = false;
    [SerializeField] private GameObject Projectile;
    private int IndexNumber = 1;

    private void Start()
    {
        GameManager.SingleDamage += Damage;
    }
    private void Damage(int RakeNumber)
    {
        if (!isInstantiate)
        {
            Instantiate(Projectile, this.transform);
            isInstantiate = true;
        }
    }
}
