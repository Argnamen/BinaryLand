using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModObject : MonoBehaviour
{
    [SerializeField] private GameObject Object;

    private void Spawn(bool bl, string name)
    {
        Instantiate(Object, this.transform.position + Object.transform.position, Object.transform.rotation);
    }

    private void OnEnable()
    {

    }
}
