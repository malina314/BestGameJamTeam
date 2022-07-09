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

    private void Start()
    {
        //Debug.Log("I ADDED METHOD TO EVENT");
        OnDeath += giveReward;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(new Vector3(-10, 0, 0));
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= attackDelay)
        {
            elapsed = elapsed % 1f;
            TryToAttack<WarriorEntity>();
        }
    }

    private void giveReward(Entity sender)
    {
        Debug.Log("I GIVE REWARD");
        EconomyHandler bank = FindObjectOfType<EconomyHandler>();
        bank.addBalance(reward);
    }
}