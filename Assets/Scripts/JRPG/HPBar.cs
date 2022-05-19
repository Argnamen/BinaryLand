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

    private float StartHP;

    public static int BossAction = 0;

    private static int Damage;
    private static int PlayerAction = 0;

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
            }
            else
            {
                if (BossAction == 0)
                {
                    if (PlayerAction == 0)
                    {
                        Damage = Random.Range(1, damage - 1);
                        ++PlayerAction;
                    }
                    else
                    {
                        PlayerAction = 0;
                    }

                    if(Damage == 0)
                    {
                        Dodge();
                    }
                    if(Damage >= damage)
                    {
                        Damage *= 4;
                        Krit();
                    }

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
                        ++PlayerAction;
                    }
                    else
                    {
                        PlayerAction = 0;
                    }

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
        if (TryGetComponent<Slider>(out var slider))
        {
            HP = HP + ((1 / StartHP) * sheldPoints);
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
        if (TextDodged != null)
        {
            TextDodged.text = "Dodge";

            await Task.Delay(1 * 1000);

            TextDodged.text = "";
        }
    }

    private async void Krit()
    {
        if (TextDodged != null)
        {
            TextDodged.text = "Critical";

            await Task.Delay(1 * 1000);

            TextDodged.text = "";
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
