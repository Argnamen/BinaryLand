using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGame : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        UINumbersControl.roundAction.Invoke(nextLevel);
    }
}
