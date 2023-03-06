using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Transform target;
    [SerializeField] private NavMeshAgent agent;
    private float time;
    [SerializeField] private float cooldown;
    private int state = 0;
    private UnityEvent behaviour;
    private void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        behaviour = new UnityEvent();
        behaviour.AddListener(RoamingBehaviour);
        UpdateTargetLocation();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (WillTaregetBeChescked())
        {
            UpdateTargetLocation();
        }
        behaviour.Invoke();
    }
    private void Shout()
    {
        Debug.Log("rawr");
    }
    private bool WillTaregetBeChescked()
    {
        if (time > cooldown)
        {
            time = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void CombatBehaviour()
    {
        agent.speed = 0;
    }
    private void RoamingBehaviour()
    {
        agent.speed = 5;
    }
    private void HuntingBehaviour()
    {
        agent.speed = 5;
    }
    private void Attack()
    {

    }
    private void UpdateTargetLocation()
    {
        agent.destination = GetTargetPosition();
    }
    private Vector3 GetTargetPosition()
    {
        Vector3 targetPosition = target.position;
        return targetPosition;
    }
    private void StateController(bool increase)
    {
        if (increase)
        {
            state++;
        }
        else
        {
            state--;
        }
        UpdateState();
    }
    private void UpdateState()
    {
        if (state == 0)
        {
            cooldown = 10;
            UpdateTargetLocation();
        }
        else if(state == 1)
        {
            cooldown = 5;
            UpdateTargetLocation();
        }
        else if (state == 2)
        {
            cooldown = 2;
            UpdateTargetLocation();
        }
        else if (state ==3)
        {
            cooldown = 1;
            UpdateTargetLocation();
        }
        else if (state ==4)
        {
            cooldown = 0.5f;
        }
        else if (state == 5)
        {
            cooldown = 0.5f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        StateController(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        StateController(false);
    }
}
