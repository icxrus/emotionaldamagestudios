using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInventory : MonoBehaviour
{
    public GameObject _playerInvemtory1;
    public GameObject _playerInvemtory2;
    // Start is called before the first frame update
    void Start()
    {
        _playerInvemtory1 = GameObject.Find("PlayerCapsule/Inventory/Character");
        _playerInvemtory2 = GameObject.Find("PlayerCapsule/Inventory/Inventory");
        _playerInvemtory1.SetActive(true);
        _playerInvemtory2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            _playerInvemtory1.SetActive(false);
            _playerInvemtory2.SetActive(false);
        }
    }
    public void DecativateI()
    {
        _playerInvemtory1.SetActive(false);
        _playerInvemtory2.SetActive(false);
    }
}
