using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool targetInArea = false;
    public void AttackCheck(float iDamage, DamageResieving iDamageResiever)
    {
        if (targetInArea)
        {
            iDamageResiever.ResievingDamage(iDamage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        targetInArea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        targetInArea = false;
    }
}
