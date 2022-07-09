using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    [SerializeField]
    private int reward;

    public int Reward { get => reward; set => reward = value; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            tryToAttack<TowerEntity>();
        }
    }

    private void Start()
    {
        Debug.Log("I ADDED METHOD TO EVENT");
        OnDeath += giveReward;
    }

    private void giveReward(Entity sender)
    {
        Debug.Log("I GIVE REWARD");
        EconomyHandler bank = FindObjectOfType<EconomyHandler>();
        bank.addBalance(reward);
    }
}