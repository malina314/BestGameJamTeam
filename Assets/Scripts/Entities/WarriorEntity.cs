using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEntity : Entity
{
    [SerializeField]
    private int cost;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= attackDelay)
        {
            elapsed = elapsed % 1f;
            TryToAttack<EnemyEntity>();
        }
    }
}
