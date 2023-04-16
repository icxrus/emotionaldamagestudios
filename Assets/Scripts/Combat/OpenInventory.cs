using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject _playerInventory;
    public GameObject _playerEquiped;
    // The quick slots are controlled seperatly.

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { ToggleInventory(); }
    }
    private void ToggleInventory()
    {
        if (_playerInventory.activeSelf == true)
        {
            _playerInventory.SetActive(false);
            _playerEquiped.SetActive(false);
        }
        else if (_playerInventory.activeSelf == false)
        {
            _playerInventory.SetActive(true);
            _playerEquiped.SetActive(true);
        }
    }
}
