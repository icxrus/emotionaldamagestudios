using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyRun : MonoBehaviour
{
    [SerializeField] private Animator makeRun;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            makeRun.SetBool("Run", true);
        }
    }
}
