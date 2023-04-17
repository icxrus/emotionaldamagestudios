using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBunny : MonoBehaviour
{
   
    [SerializeField] private GameObject bunny;
    [SerializeField] private GameObject wall;

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bunny"))
        {
            Destroy(bunny);
            Destroy(wall);
        }
    }
}
