using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class JRPGGameManager : MonoBehaviour
{
    [SerializeField] GameObject WinIcon, LoseIcon;

    private async void WinActivate()
    {
        EventList.Swipe = null;

        WinIcon.SetActive(true);

        EventList.SingleDamagePlayer = null;

        if (EventList.WarningText != null)
        {
            EventList.WarningText.Invoke(false);
        }

        await Task.Delay(10);

        EventList.WarningText = null;
    }

    private void LoseActivate()
    {
        EventList.Swipe = null;

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
