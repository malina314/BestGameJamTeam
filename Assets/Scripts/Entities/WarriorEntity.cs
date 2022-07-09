using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEntity : Entity
{
    [SerializeField]
    private int cost;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TryToAttack<EnemyEntity>();
        }
    }
}
