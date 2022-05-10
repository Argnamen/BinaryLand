using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraActivate : MonoBehaviour
{
    [SerializeField] private bool PlayerAura, MirrorPlayerAura;
    private void Activate(bool status)
    {
        if(TryGetComponent<SpriteRenderer>(out var spriteRenderer))
        {
            spriteRenderer.enabled = status;
        }
    }

    private void OnEnable()
    {
        if (PlayerAura)
        {
            EventList.PlayerAura += Activate;
        }
        else if (MirrorPlayerAura)
        {
            EventList.MirrorPlayerAura += Activate;
        }
    }

    private void OnDisable()
    {
        if (PlayerAura)
        {
            EventList.PlayerAura -= Activate;
        }
        else if (MirrorPlayerAura)
        {
            EventList.MirrorPlayerAura -= Activate;
        }
    }
}
