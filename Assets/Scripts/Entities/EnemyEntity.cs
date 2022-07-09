using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            tryToAttack<TowerEntity>();
        }
    }
}
