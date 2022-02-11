using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipScale : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform player = animator.gameObject.transform;
        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform player = animator.gameObject.transform;
        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
    }
}
