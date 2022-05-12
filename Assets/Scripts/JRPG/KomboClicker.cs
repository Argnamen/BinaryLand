using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class KomboClicker : MonoBehaviour
{
    [SerializeField] private int InputLagMicsec = 500;
    [SerializeField] private int KomboTimerSec = 5;

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

            DamagePoints += 5;

            await Task.Delay(InputLagMicsec);

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

        EventList.ButtonActivate.Invoke(false);

        await Task.Delay(5);
        EventList.WarningText.Invoke(false);

        await Task.Delay(KomboTimerSec * 1000);

        this.GetComponent<Button>().enabled = false;

        EventList.SingleDamage.Invoke(DamagePoints);

        await Task.Delay(5);

        this.gameObject.SetActive(false);

        await Task.Delay(5);
        EventList.BattleStart.Invoke();
    }

    private async void DeactivateStartScene()
    {
        await Task.Delay(1);

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
