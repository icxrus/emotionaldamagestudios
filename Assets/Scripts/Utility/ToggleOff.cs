using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOff : MonoBehaviour
{
    [SerializeField] private GameObject _ToggleableObject;
    public void Off()
    {
        if (_ToggleableObject.activeSelf == true)
        {
            _ToggleableObject.SetActive(false);
        }
    }
}
