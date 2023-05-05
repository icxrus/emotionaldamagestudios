using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOn : MonoBehaviour
{
    [SerializeField] private GameObject _ToggleableObject;
    public void On()
    {
        if (_ToggleableObject.activeSelf == false)
        {
            _ToggleableObject.SetActive(true);
        }
    }
}
