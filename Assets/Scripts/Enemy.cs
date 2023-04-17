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
    [SerializeField] private EnemyAttack enemyAttack;

    [SerializeField] private SphereCollider[] stateSpheres;

    public Transform target;
    [SerializeField] private NavMeshAgent agent;
    private float time = 0;
    [SerializeField] private float cooldown;
    private float lingerTime = 0;
    [SerializeField] private float lingerCooldown;
    private float attackTime = 0;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDelay;
    [SerializeField] private float animationTime;
    private bool attacking;
    [SerializeField] private int state = 0;
    private UnityEvent behaviour;
    [SerializeField] private Transform[] roamingLocations;

    [SerializeField] private Animator bearAnimator;

    [SerializeField] private HealthSystemForDummies ownHealthSystem;
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
        if (ownHealthSystem.IsAlive ==  true)
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
                    enemyAttack.AttackCheck(damage, target.GetComponent<DamageResieving>());
                    attacking = false;
                    agent.isStopped = false;
                    Tracking();
                }
                else if(attackTime > attackDelay - animationTime)
                {
                    bearAnimator.SetTrigger("Attack1");
                }
            }
            if (!attacking)
            {
                if (agent.velocity.x == 0 || agent.velocity.z == 0)
                {
                    bearAnimator.SetBool("WalkForward", false);
                    bearAnimator.SetBool("Idle", true);
                }
                else
                {
                    bearAnimator.SetBool("Idle", false);
                    bearAnimator.SetBool("WalkForward", true);
                }
            }
        }
        else
        {
            agent.isStopped = true;

            bearAnimator.SetBool("Death", true);
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
        if (Vector3.Distance(transform.position, agent.destination) < 5)
        {
            lingerTime += Time.deltaTime;
        }
        if (lingerTime > lingerCooldown)
        {
            agent.destination = roamingLocations[Random.Range(0,roamingLocations.Length)].position;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            StateController(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            StateController(false);
        }
    }
}
