using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class FightButton : MonoBehaviour
{
    private void ButtonActivate(bool status)
    {
        this.gameObject.SetActive(status);
    }

    public void FightStart()
    {
        EventList.BattleStart.Invoke();
    }

    private async void DeactivateStartScene()
    {
        await Task.Delay(1);

        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(EventList.ButtonActivate != null)
        {
            EventList.ButtonActivate = null;
        }
        else
        {
            DeactivateStartScene();
        }

        EventList.ButtonActivate += ButtonActivate;
    }

    private void OnDestroy()
    {
        EventList.ButtonActivate -= ButtonActivate;
    }
}
