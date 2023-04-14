using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearDragon : MonoBehaviour
{
    [SerializeField] private Animator playerNearD;

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject dragon;

    [SerializeField] private bool PlayerNear;
    [SerializeField] private float speed = -500;
    [SerializeField] private float timer = 4f;

    //Player enters trigger sphere and makes animation happen.
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerNear", true);
            PlayerNear = true;
        }
    }

    public void Update()
    {
        if (PlayerNear == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                dragon.transform.position = Vector3.MoveTowards(dragon.transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
        
    }

    // Makes the bool values for PlayerNear false, but does not do anything.
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearD.SetBool("PlayerNear", false);
            PlayerNear = false;
        }
    }
}
