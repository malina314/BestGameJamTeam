using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArealDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private bool showDebug;
    [SerializeField]
    private int damageDelay;
    public int Damage { get => damage; set => damage = value; }
    public int DamageDelay { get => damageDelay; set => damageDelay = value; }

    private int frames;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }

    private void applyDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<EnemyEntity>(out var entity))
            {
                if (!entity.gameObject.Equals(gameObject))
                {
                    Debug.Log("arrow attack");
                    entity.DealDamage(Damage);
                }
            }
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (frames > damageDelay) applyDamage();
        else frames++;
    }
}
