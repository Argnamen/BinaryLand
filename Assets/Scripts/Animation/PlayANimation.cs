using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayANimation : MonoBehaviour
{
    public static bool OnAnimation;

    private void Update()
    {
        if (OnAnimation)
        {
            this.GetComponent<Animation>().enabled = true;
        }
        else
        {
            this.GetComponent<Animation>().enabled = false;
        }
    }
}
