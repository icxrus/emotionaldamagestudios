using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleEventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent AddNewEvent;

    // Used ofr collition events with player.
    // Type new if statment for other triggers.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddNewEvent.Invoke();
            Debug.Log("TriggerHit");
        }
    }
}
