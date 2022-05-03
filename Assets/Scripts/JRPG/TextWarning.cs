using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWarning : MonoBehaviour
{
    private void TextUpdate(bool action)
    {
        if(TryGetComponent<TextMeshProUGUI>(out var text))
        {
            if (action)
            {
                text.text = "ATTACK";
            }
            else
            {
                text.text = "";
            }
        }
    }

    private void OnEnable()
    {
        EventList.WarningText += TextUpdate;
    }

    private void OnDisable()
    {
        EventList.WarningText -= TextUpdate;
    }
}
