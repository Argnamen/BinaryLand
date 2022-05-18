using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWarning : MonoBehaviour
{
    private void TextUpdate(bool action)
    {
        if (TryGetComponent<TextMeshProUGUI>(out var text))
        {
            if (action)
            {
                HPBar.BossAction = Random.Range(0, 2);
                if (HPBar.BossAction == 0)
                    text.text = "";
                else
                    text.text = "";
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
