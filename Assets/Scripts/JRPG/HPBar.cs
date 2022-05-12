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

    private float StartHP;

    public static int BossAction = 0;

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

                        break;
                }
            }
            else
            {
                if (BossAction == 0)
                {
                    damage = Random.Range(0, damage + 1);

                    if(damage == 0)
                    {
                        Dodge();
                    }

                    HP = HP - ((1 / StartHP) * damage);
                    slider.value = HP;
                }
            }

            if(HP <= 0 && IsEvil)
            {
                EventList.Win.Invoke();
            }
            else if(HP <= 0)
            {
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
