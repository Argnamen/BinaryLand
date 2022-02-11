using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (MirrorPlayerDetected.isMirrorPlayer && PlayerDetected.isPlayer)
        {
            this.GetComponent<Animator>().enabled = true;
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            UINumbersControl.roundAction.Invoke(nextLevel);
        }
    }
}
