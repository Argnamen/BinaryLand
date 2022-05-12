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

    public int EvilDamagePoints = 1;

    private int UltimateAction = 2, SaveUltimateAction = 2;

    private int NumberPlayerAction = 1, SaveNumberPlayerAction = 1;

    private static int[] ActionList = new int[2]; //1-damage, 2-shild, 3-Ult
    public void Attack(int playerNumber)
    {
        ActionList[playerNumber - 1] = 1;

        //ActionComplite();
        ButtonActivate();
    }

    public void Sheld()
    {
        ActionList[0] = 2;

        //ActionComplite();
        ButtonActivate();
    }

    public void Heal()
    {
        ActionList[1] = 2;

        //ActionComplite();
        ButtonActivate();
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

        //ActionComplite();
        ButtonActivate();
    }

    private async void EvilDamage()
    {
        EventList.PlayerAura.Invoke(false);
        EventList.MirrorPlayerAura.Invoke(false);

        await Task.Delay(1 * 500);

        if (EventList.SingleDamagePlayer != null)
        {
            EventList.SingleDamagePlayer.Invoke(EvilDamagePoints);

            EventList.Swipe.Invoke();
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
    }

    private void WarningActivate(bool action)
    {
        if (EventList.WarningText != null)
        {
            EventList.WarningText.Invoke(action);
        }
    }

    private void ButtonActivate()
    {
        if (ActionList[0] != 0 && ActionList[1] != 0)
        {
            int kombo = 0;

            for (int i = 0; i < ActionList.Length; i++)
            {
                switch (ActionList[i])
                {
                    case 1:
                        ++kombo;
                        if (i == 1 && kombo == 2)
                        {
                            //EventList.SingleDamage.Invoke(DamagePoints * 4);

                            EventList.KomboSkill.Invoke();
                        }
                        break;
                }
            }

            if (kombo != 2)
            {
                EventList.ButtonActivate.Invoke(true);
            }
        }
        else
        {
            EventList.ButtonActivate.Invoke(false);
        }

        InterectableUpdate(true);
    }

    private async void ActionComplite()
    {
        //EventList.PlayerAura.Invoke(false);
        //EventList.MirrorPlayerAura.Invoke(true);

        InterectableUpdate(true);

        EventList.ButtonActivate.Invoke(false);

        if (ActionList[0] != 0 && ActionList[1] != 0)
        {
            --UltimateAction;
            //--NumberPlayerAction;

            for (int i = 0; i < ActionList.Length; i++)
            {
                switch (ActionList[i])
                {
                    case 3:
                        EventList.SingleDamage.Invoke(UltimateDamagePoints);
                        break;
                }
            }

            EvilDamage();

            InterectableUpdate(false);
            WarningActivate(false);

            await Task.Delay(2 * 1000);

            InterectableUpdate(true);

            int kombo = 0;

            for (int i = 0; i < ActionList.Length; i++)
            {
                switch (ActionList[i])
                {
                    case 1:
                        ++kombo;
                        if (i == 1 && kombo == 2)
                        {
                            //EventList.SingleDamage.Invoke(DamagePoints * 4);

                            //EventList.KomboSkill.Invoke();
                        }
                        else if (i == 1)
                        {
                            EventList.SingleDamage.Invoke(DamagePoints);
                        }
                        break;
                    case 2:
                        if (i == 1)
                            EventList.MassHeal.Invoke(HealPoints);
                        if (i == 0)
                            EventList.SingleDamage.Invoke(DamagePoints * 2);
                        break;
                }
            }

            UltimateComplite();
            CleanActions();


            if (EventList.WarningText != null)
            {
                EventList.WarningText.Invoke(true);
            }
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

    private void OnEnable()
    {
        if (EventList.BattleStart != null)
        {
            EventList.BattleStart = null;
        }

        EventList.BattleStart += ActionComplite;
    }

    private void OnDestroy()
    {
        EventList.BattleStart -= ActionComplite;
    }
}
