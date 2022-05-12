using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class JRPGGameManager : MonoBehaviour
{
    [SerializeField] GameObject WinIcon, LoseIcon;

    private async void WinActivate()
    {
        WinIcon.SetActive(true);

        EventList.SingleDamagePlayer = null;

        EventList.WarningText.Invoke(false);

        await Task.Delay(10);

        EventList.WarningText = null;
    }

    private void LoseActivate()
    {
        LoseIcon.SetActive(true);

        EventList.SingleDamagePlayer = null;


        EventList.WarningText = null;
    }
    private async void GameLoop()
    {
        
    }
    private void Update()
    {
        //GameLoop();
    }

    private void OnEnable()
    {
        EventList.Win += WinActivate;
        EventList.Lose += LoseActivate;

        //EventList.ButtonActivate.Invoke(false);
    }

    private void OnDisable()
    {
        EventList.Win -= WinActivate;
        EventList.Lose -= LoseActivate;
    }
}
