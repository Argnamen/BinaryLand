using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DodgeTextEvent : MonoBehaviour
{
    [SerializeField] private bool IsEvil;

    private void TextUpdate(string text)
    {
        if(TryGetComponent<TextMeshProUGUI>(out var proUGUI))
        {
            proUGUI.text = text;
        }
    }

    private void OnEnable()
    {
        if(!IsEvil)
            EventList.DodgeTextUpdate += TextUpdate;
    }

    private void OnDestroy()
    {
        if(!IsEvil)
        EventList.DodgeTextUpdate -= TextUpdate;
    }
}
