using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyEntity : Entity
{
    [SerializeField]
    private int reward;
    [SerializeField]
    private NavMeshAgent agent;

    public int Reward { get => reward; set => reward = value; }
    public Transform targetPoint;

    private float delay = 1f;
    private void Start()
    {
        //Debug.Log("I ADDED METHOD TO EVENT");
        OnDeath += giveReward;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(targetPoint.position);
        
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= attackDelay)
        {
            elapsed = elapsed % 1f;
            TryToAttack<WarriorEntity>();
        }

        //DEATH BY CASTLE
        delay -= Time.deltaTime;        
        if(delay <= 0f)
        {
            if (Vector3.Distance(targetPoint.position,transform.position) < 1f)
            {
                FindObjectOfType<GameController>()?.DealDamageToCastle(1);
                reward = 0;
                KillEntity();
            }
        }
    }

    private void giveReward(Entity sender)
    {
        Debug.Log("I GIVE REWARD");
        EconomyHandler bank = FindObjectOfType<EconomyHandler>();
        bank.addBalance(reward);
    }
}