using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInterectable : MonoBehaviour
{
    [SerializeField] private bool IsUltimate = false;
    private void IntUpdate()
    {
        if(TryGetComponent<Button>(out var button))
        {
            if (IsUltimate)
            {
                if (button.interactable)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        }
    }

    private void IntUpdate(bool active)
    {
        if (TryGetComponent<Button>(out var button))
        {
            if (!IsUltimate)
            {
                button.interactable = active;
            }
        }
    }

    private void OnEnable()
    {
        EventList.InterectableUpdate += IntUpdate;
        EventList.InterectableAction += IntUpdate;
    }

    private void OnDisable()
    {
        EventList.InterectableUpdate -= IntUpdate;
        EventList.InterectableAction -= IntUpdate;
    }
}
