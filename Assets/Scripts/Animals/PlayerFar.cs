using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFar : MonoBehaviour
{

    [SerializeField] private Animator playerNearD;
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerFar", true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerFar", false);
        }
    }
}
