using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEntity : Entity
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            tryToAttack<EnemyEntity>();
        }
    }
}
