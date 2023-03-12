using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform target;
    [SerializeField] private NavMeshAgent agent;
    private float time = 0;
    [SerializeField] private float cooldown;
    private float lingerTime = 0;
    [SerializeField] private float lingerCooldown;
    private float attackTime = 0;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int state = 0;
    private UnityEvent behaviour;
    [SerializeField] private Vector3[] roamingLocations;
    private void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        behaviour = new UnityEvent();
        RoamingBehaviour();
    }
    private void Update()
    {
        time += Time.deltaTime;
        behaviour.Invoke();
    }
    private void Shout()
    {
        Debug.Log("rawr");
    }
    private void CombatBehaviour()
    {
        attackTime = 0;
        Attack();
    }
    private void RoamingBehaviour()
    {
        behaviour.AddListener(UpdateRoamingLocation);
    }
    private void HuntingBehaviour()
    {
        Tracking();
    }
    private void Attack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > attackCooldown)
        {
            target.GetComponent<DamageResieving>().ResievingDamage(10);
            attackTime = 0;
        }
    }
    private void Tracking()
    {
        if (WillTaregetBeChescked())
        {
            UpdateTargetLocation();
        }
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
    private void UpdateTargetLocation()
    {
        
            agent.destination = GetTargetPosition();
    }
    private void UpdateRoamingLocation()
    {
        if (Vector3.Distance(transform.position, agent.destination) < 1)
        {
            lingerTime += Time.deltaTime;
        }
        if (lingerTime > lingerCooldown)
        {
            agent.destination = roamingLocations[Random.Range(0,3)];
            lingerTime = 0;
        }
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
            behaviour.RemoveAllListeners();
            behaviour.AddListener(RoamingBehaviour);
            agent.speed = 5;
        }
        else if(state == 1)
        {
            cooldown = 5;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(HuntingBehaviour);
            agent.speed = 5;
        }
        else if (state == 2)
        {
            cooldown = 2;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(HuntingBehaviour);
            agent.speed = 5;
        }
        else if (state ==3)
        {
            cooldown = 1;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(HuntingBehaviour);
            agent.speed = 5;
        }
        else if (state ==4)
        {
            cooldown = 0.5f;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(CombatBehaviour);
            agent.speed = 0;
        }
        else if (state == 5)
        {
            cooldown = 0.5f;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(CombatBehaviour);
            agent.speed = 0;
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
