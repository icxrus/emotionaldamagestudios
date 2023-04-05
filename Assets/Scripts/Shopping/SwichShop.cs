using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwichShop : MonoBehaviour
{
    public GameObject Shop1;
    public GameObject Shop2;

    // Update is called once per frame
    void Update()
    {
        // Move to diifferent Shop fom 1 to 2
        if(Shop1.activeSelf == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Shop2.SetActive(true);
            Shop1.SetActive(false);
            
        }
        // from 2 to 1
        else if (Shop2.activeSelf == true && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Shop1.SetActive(true);
            Shop2.SetActive(false);
        }
    }
    public void GoToShop1()
    {
        Shop1.SetActive(true);
        Shop2.SetActive(false);
    }
    public void GoToShop2()
    {
        Shop1.SetActive(false);
        Shop2.SetActive(true);
    }
}
