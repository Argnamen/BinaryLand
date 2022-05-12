using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManagerJRPG : MonoBehaviour
{
    public UnityEvent StartLoop, Loop, FinishLoop;

    public UnityEvent Win, Lose;

    public UnityEvent InterectableUpdate;
    public UnityEvent<bool> InterectableAction;

    public UnityEvent<bool> WarningText;

    public UnityEvent<int> SingleDamage, SingleSheld, SingleDamagePlayer, MassHeal;

    public UnityEvent<int> LevelStart;

    public UnityEvent<bool, string, string> OnBattle;

    public UnityEvent<Vector2, float> MovePlayer;

    public UnityEvent<bool> PlayerAura, MirrorPlayerAura;
}
