using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool isDeath = false;
    private void Update()
    {
        if (isDeath)
            Destroy(this.gameObject);
    }
}
