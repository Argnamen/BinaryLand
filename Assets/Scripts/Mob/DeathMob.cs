using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMob : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Mob>().enabled = false;
        animator.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
