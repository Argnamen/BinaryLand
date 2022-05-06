using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int
        DamagePoints = 1,
        SheldPoints = 1,
        UltimateDamagePoints = 2;

    private int UltimateAction = 2, SaveUltimateAction = 2;

    private int NumberPlayerAction = 1, SaveNumberPlayerAction = 1;

    private List<int> ActionList = new List<int>(); //1-damage, 2-shild, 3-Ult
    public async void Attack()
    {
        InterectableUpdate(false);

        await Task.Delay(1 * 500);

        InterectableUpdate(true);

        ActionList.Add(1);

        ActionComplite();
    }

    public async void Sheld()
    {

        InterectableUpdate(false);

        await Task.Delay(1 * 500);

        InterectableUpdate(true);

        ActionList.Add(2);

        ActionComplite();
    }

    public async void UltimateAttack()
    {
        EventList.SingleSheld.Invoke(SheldPoints);

        EventList.InterectableUpdate.Invoke();

        InterectableUpdate(false);

        await Task.Delay(1 * 500);

        InterectableUpdate(true);

        if (UltimateAction <= 0)
        {
            ActionList.Add(3);

            UltimateAction = SaveUltimateAction;
        }

        ActionComplite();
    }

    private async void EvilDamage()
    {
        EventList.PlayerAura.Invoke(false);
        EventList.MirrorPlayerAura.Invoke(false);

        await Task.Delay(1 * 500);

        if (EventList.SingleDamagePlayer != null)
        {
            EventList.SingleDamagePlayer.Invoke(DamagePoints);
        }

    }

    private void UltimateComplite()
    {
        if (UltimateAction == 0)
        {
            if (EventList.InterectableUpdate != null)
            {
                EventList.InterectableUpdate.Invoke();
            }
        }
    }

    private void InterectableUpdate(bool action)
    {
        if (EventList.InterectableAction != null)
        {
            EventList.InterectableAction.Invoke(action);
        }
        if (EventList.WarningText != null)
        {
            EventList.WarningText.Invoke(action);
        }
    }

    private async void ActionComplite()
    {
        EventList.PlayerAura.Invoke(false);
        EventList.MirrorPlayerAura.Invoke(true);

        if (ActionList.Count == 2)
        {
            --UltimateAction;
            //--NumberPlayerAction;

            for (int i = 0; i < ActionList.Count; i++)
            {
                switch (ActionList[i])
                {
                    case 2:
                        EventList.SingleSheld.Invoke(SheldPoints);
                        break;
                    case 3:
                        EventList.SingleDamage.Invoke(UltimateDamagePoints);
                        break;
                }
            }

            EvilDamage();

            InterectableUpdate(false);

            await Task.Delay(2 * 1000);

            InterectableUpdate(true);

            for (int i = 0; i < ActionList.Count; i++)
            {
                switch (ActionList[i])
                {
                    case 1:
                        EventList.SingleDamage.Invoke(DamagePoints);
                        break;
                }
            }

            UltimateComplite();
            ActionList.Clear();

            EventList.PlayerAura.Invoke(true);
            EventList.MirrorPlayerAura.Invoke(false);
        }
    }
}
