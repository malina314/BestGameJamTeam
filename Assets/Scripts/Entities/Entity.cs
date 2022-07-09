using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float range;

    public delegate void EntityEventHandler(Entity sender);
    public event EntityEventHandler OnHealthChange;
    public event EntityEventHandler OnDamageDealt;
    public event EntityEventHandler OnDeath;

    //debug fields
    [SerializeField]
    private bool showDebug;


    public int Health { get => health; set => handleDamage(value); }

    void handleDamage(int h)
    {
        health = h;
        if(health <= 0)
        {
            if (OnDeath != null)
            {
                OnDeath(this);
            }
            Destroy(gameObject);
        }

        if(OnHealthChange != null)
        {
            OnHealthChange(this);
        }
    }

    public int Damage { get => damage; set => damage = value; }
    public float Range { get => range; set => range = value; }
    public int MaxHealth { get => maxHealth; }

    public void attack(Entity victim)
    {
        victim.Health -= this.Damage;
        if (OnDamageDealt != null)
        {
            OnDamageDealt(this);
        }
    }

    public void tryToAttack<T>() where T : Entity // wywo³aj co jakiœ czas ¿eby zaatakowaæ
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (var collider in colliders)
        {
            if( collider.TryGetComponent<T>(out var entity))
            {
                if (!entity.gameObject.Equals(gameObject))
                {
                    this.attack(entity);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.D))
        {
            tryToAttack<Entity>();
        }
    }
}
