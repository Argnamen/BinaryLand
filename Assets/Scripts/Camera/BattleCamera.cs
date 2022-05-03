using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    public void Battle(bool OnCamera, string name)
    {
        this.gameObject.SetActive(OnCamera ? false : true);
    }
    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
