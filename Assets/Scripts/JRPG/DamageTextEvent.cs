using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class DamageTextEvent : MonoBehaviour
{
    [SerializeField] private bool IsEvil;

    private async void TextUpdate(string text)
    {
        if (TryGetComponent<TextMeshProUGUI>(out var proUGUI))
        {
            proUGUI.text = text;

            await Task.Delay(1 * 1000);

            proUGUI.text = "";
        }
    }

    private void OnEnable()
    {
        if (!IsEvil)
            EventList.PlayerDamageText += TextUpdate;
        else
            EventList.EvilDamageText += TextUpdate;
    }

    private void OnDestroy()
    {
        if (!IsEvil)
            EventList.PlayerDamageText -= TextUpdate;
        else
            EventList.EvilDamageText -= TextUpdate;
    }


}
