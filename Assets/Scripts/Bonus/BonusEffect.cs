using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEffect : MonoBehaviour
{
    public enum EffectsList
    {
        Speed, God, Flight
    }

    public EffectsList Effect;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MirrorPlayer>() || collision.GetComponent<Player>())
        {
            switch (Effect)
            {
                case EffectsList.God:
                    PlayerMoving.isGod = true;
                    break;
                case EffectsList.Flight:
                    PlayerMoving.isFlight = true;
                    break;
                case EffectsList.Speed:
                    PlayerMoving.isSpeed = true;
                    break;
            }
            Destroy(this.gameObject);
        }
    }
}
