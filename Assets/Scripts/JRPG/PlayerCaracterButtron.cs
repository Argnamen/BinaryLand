using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCaracterButtron : MonoBehaviour
{
    [SerializeField] private Button[] CharactersButtons = new Button[2];
    [SerializeField] private GameObject ActionButtons;
    [SerializeField] private GameObject AlternativPlayerButtons;
    public void PlayerButtons()
    {
        if(EventList.PlayerAura != null)
            EventList.PlayerAura.Invoke(true);

        if(EventList.MirrorPlayerAura != null)
        EventList.MirrorPlayerAura.Invoke(false);

        SetCharactersButtons(false);

        SetActionButtons(true);
    }

    public void MirrorPlayerButtons()
    {
        if(EventList.PlayerAura != null)
            EventList.PlayerAura.Invoke(false);

        if(EventList.MirrorPlayerAura != null)
        EventList.MirrorPlayerAura.Invoke(true);

        SetCharactersButtons(false);

        SetActionButtons(true);
    }

    private void SetCharactersButtons(bool status)
    {
        if (CharactersButtons[0] != null)
        {
            //CharactersButtons[0].gameObject.SetActive(status); 
        }
        if(CharactersButtons[1] != null)
        {
            //CharactersButtons[1].gameObject.SetActive(status);
        }

        else
        {
            return;
        }

        ActionButtons.SetActive(false);
    }

    private void SetActionButtons(bool status)
    {
        ActionButtons.SetActive(status);
        AlternativPlayerButtons.SetActive(!status);
    }

    private void OnEnable()
    {
        EventList.InterectableAction += SetCharactersButtons;
    }

    private void OnDestroy()
    {
        EventList.InterectableAction -= SetCharactersButtons;
    }
}
