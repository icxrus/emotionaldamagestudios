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
    [SerializeField] public EnemyAttack enemyAttack;

    public Transform target;
    [SerializeField] private NavMeshAgent agent;
    private float time = 0;
    [SerializeField] private float cooldown;
    private float lingerTime = 0;
    [SerializeField] private float lingerCooldown;
    private float attackTime = 0;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDelay;
    private bool attacking;
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
        attackTime += Time.deltaTime;
        if (!attacking)
        {
            behaviour.Invoke();
        }
        else
        {
            if (attackTime > attackDelay)
            {
                enemyAttack.AttackCheck(10, target.GetComponent<DamageResieving>());
                attacking = false;
                agent.isStopped = false;
                Tracking();
            }
        }
    }
    private void Shout()
    {
        Debug.Log("rawr");
    }
    private void RotateAtTarget()
    {
        gameObject.transform.LookAt(target);
    }
    private void CombatBehaviour()
    {
        Tracking();
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
        if (attackTime > attackCooldown)
        {
            agent.isStopped = true;
            attackTime = 0;
            Shout();
            attacking = true;
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
            agent.destination = roamingLocations[Random.Range(0,roamingLocations.Length)];
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
            behaviour.AddListener(RotateAtTarget);
        }
        else if (state == 5)
        {
            cooldown = 0.5f;
            behaviour.RemoveAllListeners();
            behaviour.AddListener(CombatBehaviour);
            behaviour.AddListener(RotateAtTarget);
        }
    }
    private void OnTriggerEnter()
    {
        StateController(true);
    }
    private void OnTriggerExit()
    {
        StateController(false);
    }
}
