using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageResieving : MonoBehaviour
{
    private HealthSystemForDummies healthSystem;
    [SerializeField] private float armor = 5;
    [SerializeField] private float blockValue = 0.5f;
    [SerializeField] private bool blocking = false;
    private void Start()
    {
        healthSystem = GetComponent<HealthSystemForDummies>();
    }
    //cheaks if your blocking or not and goes through armor defencess
    public void ResievingDamage(float iDamage)
    {
        if (healthSystem != null)
        {
            //add stamina demand
            if (blocking)
            {
                iDamage *= blockValue;
            }
            iDamage -= armor;
            if (!blocking)
            {
                healthSystem.AddToCurrentHealth(-iDamage);
            }
            else
            {
                healthSystem.AddToCurrentHealth(-iDamage);
            }
            Debug.Log(-iDamage);
        }
    }
    public void SetBlock(bool iBlocking)
    {
        blocking = iBlocking;
    }
    public void SetArmorBlock(float iArmor, float iBlock)
    {
        armor = iArmor;
        blockValue = iBlock;
    }
}
