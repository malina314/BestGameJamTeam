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

    new public void TryToAttack<T>() where T : Entity
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Range);
        double distance = 2*Range;
        Entity? target = null;
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<T>(out var entity))
            {
                if (!entity.gameObject.Equals(gameObject))
                {
                    float xx = entity.gameObject.transform.position.x - gameObject.transform.position.x;
                    float yy = entity.gameObject.transform.position.y - gameObject.transform.position.y;
                    float zz = entity.gameObject.transform.position.z - gameObject.transform.position.z;
                    float dist = Mathf.Sqrt(xx * xx + yy * yy + zz * zz);

                    if(distance > dist)
                    {
                        distance = dist;
                        target = entity;
                    }
                }
            }
        }
        if(target != null)
        {
            Debug.Log($"Target {target.name}");
            if( target.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            } 
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            Attack(target);
        }
    }
}
