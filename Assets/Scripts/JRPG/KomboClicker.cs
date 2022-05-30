using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class KomboClicker : MonoBehaviour
{
    [SerializeField] private int InputLagMicsec = 200;
    [SerializeField] private int KomboTimerSec = 5;
    [SerializeField] private int DamageBonus = 2;
    [SerializeField] private TextMeshProUGUI DamageNumber;

    private bool ClickComplite = true;

    private int DamagePoints = 0;
    public void ClickMultiplier()
    {
        TimerClickMultiplier();
    }

    public async void TimerClickMultiplier()
    {
        if (ClickComplite)
        {
            ClickComplite = false;

            DamagePoints += DamageBonus;

            await Task.Delay(InputLagMicsec);

            DamageNumber.text = "" + DamageBonus;

            DamageNumber.gameObject.GetComponent<DamageTextAnimation>().Animation();

            ClickComplite = true;

            Debug.Log("Click. Damage:" + DamagePoints);
        }
    }

    private void Activate()
    {
        ActivateTimer();
    }

    private async void ActivateTimer()
    {
        this.gameObject.SetActive(true);

        this.GetComponent<Button>().enabled = true;

        if(EventList.ButtonActivate != null)
            EventList.ButtonActivate.Invoke(false);

        await Task.Delay(5);

        if(EventList.WarningText != null)
            EventList.WarningText.Invoke(false);

        await Task.Delay(KomboTimerSec * 1000);

        this.GetComponent<Button>().enabled = false;
        
        if(EventList.SingleDamage != null)
            EventList.SingleDamage.Invoke(DamagePoints);

        await Task.Delay(5);

        this.gameObject.SetActive(false);

        await Task.Delay(5);
        await Task.Delay(1 * 1000);
        if (EventList.Swipe != null)
            EventList.Swipe.Invoke();
        //EventList.BattleStart.Invoke();
    }

    private async void DeactivateStartScene()
    {
        await Task.Delay(1);

        if(EventList.SingleDamage != null)
            EventList.SingleDamage.Invoke(DamagePoints);

        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        DamagePoints = 0;

        if(EventList.KomboSkill != null)
        {
            EventList.KomboSkill = null;
        }
        else
        {
            DeactivateStartScene();
        }

        EventList.KomboSkill += Activate;
    }

    private void OnDestroy()
    {
        EventList.KomboSkill -= Activate;
    }
}
