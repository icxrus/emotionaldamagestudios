using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    [SerializeField] private int attackDmgPoint = 10;
    [SerializeField] private bool attacking = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //If left clicked
        {
            attacking = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attacking)
        {
            AttackingStructure(other);
            
        }
        
    }

    private void AttackingStructure(Collider other)
    {
        if (other.CompareTag("Enemy")) //If we have enemy inside our collider
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

            }
            gameObject.GetComponent<Stamina>().ChangeDoActionBool(true); //Set action active
            if (gameObject.GetComponent<Stamina>()._hasStamina) //stamina available
            {
                other.GetComponent<DamageResieving>().ResievingDamage(attackDmgPoint); //attack enemy with current damage number
                Debug.Log("Hit enemy for: " + attackDmgPoint);

            }
            else
                Debug.Log("No stamina.");

            attacking = false;

        }
        Debug.Log("Inside collider: " + other.name);
    }

    public void UpdateDamageNumber(int newDmgNumber) //Incase we want to change the damage the player deals via script.
    {
        attackDmgPoint = newDmgNumber;
    }
}
