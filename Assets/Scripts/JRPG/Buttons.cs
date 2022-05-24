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

    private static int[] ActionMass = new int[2]; //1-damage, 2-shild, 3-Ult
    public static List<int> ActionList = new List<int>(); 
    //11-skill1 player, 12-skill2 player, 21-skill1 MirPlayer, 22-skill2 MirPlayer, 50-boss

    private void ActionListSearch(int playerNumber, int skillNumber)
    {
        for(int i = 0; i < ActionList.Count; i++)
        {
            if(ActionList[i] == playerNumber)
            {
                ActionList[i] = playerNumber * 10 + skillNumber;
            }
        }
    }
    public void Attack(int playerNumber)
    {
        switch (playerNumber - 1)
        {
            case 0:
                ActionListSearch(1, 1);
                break;
            case 1:
                ActionListSearch(2, 1);
                break;
        }
        //ActionMass[playerNumber - 1] = 1;

        //ActionComplite();
        ButtonActivate();
    }

    public void Sheld()
    {
        ActionListSearch(1, 2);

        //ActionMass[0] = 2;

        //ActionComplite();
        ButtonActivate();
    }

    public void Heal()
    {
        ActionListSearch(2, 2);

        //ActionMass[1] = 2;

        //ActionComplite();
        ButtonActivate();
    }

    public void UltimateAttack()
    {
        EventList.SingleSheld.Invoke(SheldPoints);

        EventList.InterectableUpdate.Invoke();

        if (UltimateAction <= 0)
        {
            //ActionMass[0] = 3;

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
        if (ActionList != null)
        {
            if (((ActionList[0] / 10) * (ActionList[1] / 10) * (ActionList[2] / 10)) == 10)
            {
                int kombo = 0;

                Debug.Log(ActionList[0] + " " + ActionList[1] + " " + ActionList[2]);

                for (int i = 0; i < ActionList.Count; i++)
                {
                    switch (ActionList[i])
                    {
                        case 11:
                            ++kombo;
                            break;
                        case 21:
                            ++kombo;
                            break;
                        case 50:
                            if (i != 2)
                            {
                                kombo = 0;
                            }
                            break;
                    }

                    if (kombo == 2)
                    {
                        ActionList[i - 1] = 30;
                    }
                }
                if (kombo == 2)
                {
                    //EventList.SingleDamage.Invoke(DamagePoints * 4);

                    EventList.ButtonActivate.Invoke(true);
                    //EventList.KomboSkill.Invoke();
                }
                else if (kombo != 2)
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
    }

    private async void ActionComplite()
    {
        //EventList.PlayerAura.Invoke(false);
        //EventList.MirrorPlayerAura.Invoke(true);

        InterectableUpdate(true);

        EventList.ButtonActivate.Invoke(false);

        InterectableUpdate(false);
        WarningActivate(false);

        bool isSwipe = true;

        for (int i = 0; i < ActionList.Count; i++)
        {
            if(ActionList[i] == 30)
            {
                EventList.KomboSkill.Invoke();
                ActionList[i] = 0;
                ActionList[i + 1] = 0;
                isSwipe = false;

                await Task.Delay(5 * 1000);
            }
            switch (ActionList[i])
            {
                case 11:
                    if (EventList.SingleDamage != null)
                        EventList.SingleDamage.Invoke(DamagePoints);
                    break;
                case 12:
                    if (EventList.SingleSheld != null)
                        EventList.SingleSheld.Invoke(DamagePoints);
                    break;
                case 21:
                    if(EventList.SingleDamage != null)
                        EventList.SingleDamage.Invoke(DamagePoints);
                    break;
                case 22:
                    if (EventList.MassHeal != null)
                        EventList.MassHeal.Invoke(DamagePoints);
                    break;
                case 50:
                    EvilDamage();

                    await Task.Delay(2 * 1000);

                    InterectableUpdate(true);
                    break;
            }
        }


        if (EventList.WarningText != null)
        {
            EventList.WarningText.Invoke(true);
        }
        //ActionList.Clear();

        //EventList.PlayerAura.Invoke(true);
        //EventList.MirrorPlayerAura.Invoke(false);

        ActionList.Clear();
        ActionList = new List<int>(3);

        if (EventList.Swipe != null && isSwipe)
            EventList.Swipe.Invoke();
        else
            isSwipe = true;
    }

    private void CleanActions()
    {
        for (int i = 0; i < ActionMass.Length; i++)
        {
            ActionMass[i] = 0;
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
