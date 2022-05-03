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
    public async void Attack()
    {
        --UltimateAction;
        --NumberPlayerAction;

        if (NumberPlayerAction == 0)
        {
            EvilDamage();

            NumberPlayerAction = SaveNumberPlayerAction;
        }

        InterectableUpdate(false);

        await Task.Delay(2 * 1000);

        InterectableUpdate(true);

        EventList.SingleDamage.Invoke(DamagePoints);

        UltimateComplite();
    }

    public async void Sheld()
    {
        --UltimateAction;
        --NumberPlayerAction;

        InterectableUpdate(false);

        await Task.Delay(2 * 1000);

        InterectableUpdate(true);

        EventList.SingleSheld.Invoke(SheldPoints);

        if (NumberPlayerAction == 0)
        {
            EvilDamage();

            NumberPlayerAction = SaveNumberPlayerAction;
        }

        UltimateComplite();
    }

    public async void UltimateAttack()
    {
        --NumberPlayerAction;

        EventList.SingleSheld.Invoke(SheldPoints);

        EventList.InterectableUpdate.Invoke();

        if (NumberPlayerAction == 0)
        {
            EvilDamage();

            NumberPlayerAction = SaveNumberPlayerAction;
        }

        InterectableUpdate(false);

        await Task.Delay(2 * 1000);

        InterectableUpdate(true);

        if (UltimateAction <= 0)
        {
            EventList.SingleDamage.Invoke(UltimateDamagePoints);

            UltimateAction = SaveUltimateAction;
        }
    }

    private async void EvilDamage()
    {
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
        if(EventList.WarningText != null)
        {
            EventList.WarningText.Invoke(action);
        }
    }
}
