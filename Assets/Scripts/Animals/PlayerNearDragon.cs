using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearDragon : MonoBehaviour
{
    [SerializeField] private Animator playerNearD;
    // Make sure the target is NOT nested under the Dragon
    [SerializeField] private GameObject target;
    //Make the dragon the entire structure, trigger spheres and all (Not the target though)
    [SerializeField] private GameObject dragon;

    [SerializeField] private bool PlayerNear;
    [SerializeField] private float riseSpeed = 5;
    [SerializeField] private float flySpeed = 50;
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
        //Starts a timer countdown when the player enters the trigger area
        if (PlayerNear == true)
        {
            timer -= Time.deltaTime;
        }
        // Moves the dragon to the position of the target once the timer has reached 0.
        // This is why it's important that the target is not nested because that would make the dragon move up infinitely.
        if (timer <= 0)
        {
            dragon.transform.position = Vector3.MoveTowards(dragon.transform.position, target.transform.position, riseSpeed * Time.deltaTime);
            Invoke("FlyAway", 10);
        }
    }

    //Makes the dragon fly off into the distance
    public void FlyAway()
    {
        dragon.transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
    }
}
