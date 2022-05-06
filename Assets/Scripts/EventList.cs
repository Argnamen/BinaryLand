using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventList
{
    public static UnityAction StartLoop, Loop, FinishLoop;

    public static UnityAction Win, Lose;

    public static UnityAction InterectableUpdate;
    public static UnityAction<bool> InterectableAction;

    public static UnityAction<bool> WarningText;

    public static UnityAction<int> SingleDamage, SingleSheld, SingleDamagePlayer;

    public static UnityAction<int> LevelStart;

    public static UnityAction<bool, string, string> OnBattle;

    public static UnityAction<Vector2, float> MovePlayer;

    public static UnityAction<bool> PlayerAura, MirrorPlayerAura;
}
