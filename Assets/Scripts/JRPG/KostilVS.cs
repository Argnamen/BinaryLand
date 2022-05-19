using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KostilVS : MonoBehaviour
{
    [SerializeField] private GameObject WarningText;
    private void FixedUpdate()
    {
        if(WarningText.GetComponent<TextMeshProUGUI>().text == "")
        {
            this.gameObject.SetActive(false);
        }
    }
}
