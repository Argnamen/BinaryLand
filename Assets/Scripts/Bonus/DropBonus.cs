using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBonus : MonoBehaviour
{
    [SerializeField] GameObject[] BonusList;

    private void OnDisable()
    {
        int rnd = Random.Range(0, 3);
        if(rnd == 0)
        {
            return;
        }
        else
        {
            GameObject bonus = Instantiate(BonusList[rnd-1], transform.parent);
            bonus.transform.position = this.transform.position;
        }
    }
}
