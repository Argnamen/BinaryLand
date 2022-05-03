using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float HP = 1;

    [SerializeField] private bool IsEvil;

    private float StartHP;

    private void Attack(int damage)
    {
        if(TryGetComponent<Slider>(out var slider))
        {
            HP = HP - ((1 / StartHP) * damage);
            slider.value = HP;

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
        }
    }
}
