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
        EventList.PlayerAura.Invoke(true);
        EventList.MirrorPlayerAura.Invoke(false);

        SetCharactersButtons(false);

        SetActionButtons(true);
    }

    public void MirrorPlayerButtons()
    {
        EventList.PlayerAura.Invoke(false);
        EventList.MirrorPlayerAura.Invoke(true);

        SetCharactersButtons(false);

        SetActionButtons(true);
    }

    private void SetCharactersButtons(bool status)
    {
        CharactersButtons[0].gameObject.SetActive(status);
        CharactersButtons[1].gameObject.SetActive(status);

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
