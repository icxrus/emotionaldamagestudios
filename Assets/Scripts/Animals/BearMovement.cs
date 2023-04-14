using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
    public float speed = 2;
    [SerializeField] private Animator bearWalk;
    private bool canBearMove;
    private bool canBearEat;
    [SerializeField] private GameObject target;
    public Transform meat;
    [SerializeField] private GameObject sphere;

    private void Start()
    {
        bearWalk.SetBool("WalkForward", true);
        canBearMove = true;
    }

    void Update()
    {
        if (canBearMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.LookAt(meat);
        }

        else
        {
            bearWalk.SetBool("WalkForward", false);
            bearWalk.SetBool("Sit", true);
        }

        if (canBearEat == true)
        {
            bearWalk.SetBool("Eat", true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canBearMove = false;
        }

        if (other.CompareTag("Meat"))
        {
            canBearMove = false;
            canBearEat = true;
        }

    }
}
