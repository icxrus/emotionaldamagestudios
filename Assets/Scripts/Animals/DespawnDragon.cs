using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDragon : MonoBehaviour
{
    // Make sure that the dragon and target are set to the same objects as in FlightTriggerArea
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameObject target;

    [SerializeField] private GameObject wall;

    //Destroys the dragon and target and itself on collision
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dragon"))
        {
            Destroy(dragon);
            Destroy(target);
            Destroy(wall);
        }
    }
}
