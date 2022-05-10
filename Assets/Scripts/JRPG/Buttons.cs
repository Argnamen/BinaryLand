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
        HealPoints = 1,
        UltimateDamagePoints = 2;

    private int UltimateAction = 2, SaveUltimateAction = 2;

    private int NumberPlayerAction = 1, SaveNumberPlayerAction = 1;

    private static int[] ActionList = new int[2]; //1-damage, 2-shild, 3-Ult
    public void Attack(int playerNumber)
    {
        ActionList[playerNumber - 1] = 1;

        ActionComplite();
    }

    public void Sheld()
    {
        ActionList[0] = 2;

        ActionComplite();
    }

    public void Heal()
    {
        ActionList[1] = 2;

        ActionComplite();
    }

    public void UltimateAttack()
    {
        EventList.SingleSheld.Invoke(SheldPoints);

        EventList.InterectableUpdate.Invoke();

        if (UltimateAction <= 0)
        {
            ActionList[0] = 3;

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
        //EventList.PlayerAura.Invoke(false);
        //EventList.MirrorPlayerAura.Invoke(true);

        InterectableUpdate(true);

        if (ActionList[0] != 0 && ActionList[1] != 0)
        {
            --UltimateAction;
            //--NumberPlayerAction;

            for (int i = 0; i < ActionList.Length; i++)
            {
                switch (ActionList[i])
                {
                    case 2:
                        if(i == 0)
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

            for (int i = 0; i < ActionList.Length; i++)
            {
                switch (ActionList[i])
                {
                    case 1:
                        EventList.SingleDamage.Invoke(DamagePoints);
                        break;
                    case 2:
                        if (i == 1)
                            EventList.MassHeal.Invoke(HealPoints);
                        break;
                }
            }

            UltimateComplite();
            CleanActions();
            //ActionList.Clear();

            //EventList.PlayerAura.Invoke(true);
            //EventList.MirrorPlayerAura.Invoke(false);
        }
    }

    private void CleanActions()
    {
        for (int i = 0; i < ActionList.Length; i++)
        {
            ActionList[i] = 0;
        }
    }
}
