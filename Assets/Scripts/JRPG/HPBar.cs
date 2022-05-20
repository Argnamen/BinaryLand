using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float HP = 1;

    [SerializeField] private bool IsEvil;

    [SerializeField] private TextMeshProUGUI TextDodged;

    [SerializeField] private GameObject FillArea;

    [SerializeField] private bool IsKrit, IsDodge, IsMagic;

    private float StartHP;

    public static int BossAction = 0;

    private static int Damage;
    private static int PlayerAction = 0;

    private bool IsSheld = false;

    private void Attack(int damage)
    {
        if(TryGetComponent<Slider>(out var slider))
        {
            if (IsEvil)
            {
                switch (BossAction)
                {
                    case 0:
                        HP = HP - ((1 / StartHP) * damage);
                        Debug.Log(HP);
                        slider.value = HP;
                        break;
                    case 1:
                        HP = HP - ((1 / StartHP) * damage);
                        Debug.Log(HP);
                        slider.value = HP;
                        break;
                }

                if(damage != 0)
                    EventList.EvilDamageText.Invoke("" + damage);
            }
            else
            {
                if (BossAction == 0)
                {
                    if (PlayerAction == 0)
                    {
                        if (IsSheld)
                        {
                            Damage = 0;
                        }
                        else
                        {
                            Damage = Random.Range(1, damage + 2);
                        }

                        ++PlayerAction;

                    }
                    else
                    {
                        PlayerAction = 0;
                    }

                    if (Damage == 1)
                    {
                        if (IsDodge)
                        {
                            Damage = 0;
                            Dodge();
                        }
                        else
                            Damage = 1;
                    }
                    if (Damage == damage + 1)
                    {
                        if (IsKrit)
                        {
                            Damage *= 2;
                            Krit();
                        }
                        else
                        {
                            Damage = damage;
                        }
                    }

                    if(Damage == 0)
                    {
                        IsSheld = false;
                    }

                    if (damage != 0)
                        EventList.PlayerDamageText.Invoke("" + Damage);
                    HP = HP - ((1 / StartHP) * Damage);
                    if (HP > 1)
                    {
                        HP = 1;
                    }
                    slider.value = HP;
                }
                else if (BossAction == 1)
                {
                    if (PlayerAction == 0)
                    {
                        Damage = 10;
                        Magic();
                        ++PlayerAction;
                    }
                    else
                    {
                        PlayerAction = 0;
                    }

                    if (damage != 0)
                        EventList.PlayerDamageText.Invoke("" + Damage);
                    HP = HP - ((1 / StartHP) * Damage);
                    if (HP > 1)
                    {
                        HP = 1;
                    }
                    slider.value = HP;
                }
            }

            if(HP <= 0 && IsEvil)
            {
                FillArea.SetActive(false);
                EventList.Win.Invoke();
            }
            else if(HP <= 0)
            {
                FillArea.SetActive(false);
                EventList.Lose.Invoke();
            }
        }
    }

    private void Sheld(int sheldPoints)
    {
        if(!IsSheld)
        {
            IsSheld = true;
        }

        if (TryGetComponent<Slider>(out var slider))
        {
            //HP = HP + ((1 / StartHP) * sheldPoints);
            //slider.value = HP;
        }
    }

    private void Heal(int healPoints)
    {
        if (TryGetComponent<Slider>(out var slider))
        {
            HP = HP + ((1 / StartHP) * healPoints);
            slider.value = HP;
        }
    }

    private async void Dodge()
    {
        if (EventList.DodgeTextUpdate != null)
        {
            EventList.DodgeTextUpdate.Invoke("Dodge");

            await Task.Delay(1 * 1000);

            EventList.DodgeTextUpdate.Invoke("");
        }
    }

    private async void Krit()
    {
        if (EventList.DodgeTextUpdate != null)
        {
            EventList.DodgeTextUpdate.Invoke("Critical");

            await Task.Delay(1 * 1000);

            EventList.DodgeTextUpdate.Invoke("");
        }
    }

    private async void Magic()
    {
        if (EventList.DodgeTextUpdate != null && IsMagic)
        {
            EventList.DodgeTextUpdate.Invoke("Magic");

            await Task.Delay(1 * 1000);

            EventList.DodgeTextUpdate.Invoke("");
        }
    }

    private void OnEnable()
    {
        StartHP = HP;

        HP = 1;

        if (IsEvil)
        {
            EventList.SingleDamage += Attack;
        }
        else
        {
            EventList.SingleDamagePlayer += Attack;
            EventList.SingleSheld += Sheld;
            EventList.MassHeal += Heal;
        }
    }

    private void OnDisable()
    {
        if (IsEvil)
        {
            EventList.SingleDamage -= Attack;
        }
        else
        {
            EventList.SingleDamagePlayer -= Attack;
            EventList.SingleSheld -= Sheld;
            EventList.MassHeal -= Heal;
        }
    }
}
