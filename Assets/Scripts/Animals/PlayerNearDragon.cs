using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearDragon : MonoBehaviour
{
    [SerializeField] private Animator playerNearD;
    [SerializeField] private float heightSpeed= 4;
    [SerializeField] private GameObject dragon;
    [SerializeField] private bool PlayerNear;



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerNear", true);
        }
        PlayerNear = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerNear", false);
        }
        PlayerNear = false;
    }
    float whatever;
    float secondY;
}
