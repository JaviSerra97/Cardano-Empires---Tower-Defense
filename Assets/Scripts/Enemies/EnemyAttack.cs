using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private bool stopToAttack;

    private GameObject target;
    private EnemyStats stats;
    private EnemyPath path;

    private float attackTimer = 0;

    private void Awake()
    {
        path = GetComponent<EnemyPath>();
        stats = GetComponent<EnemyStats>();
    }

    private void Update()
    {
        if (target)
        {
            //if (stopToAttack) { path.SetMoveState(false); }
            attackTimer += Time.deltaTime;
            if (attackTimer >= 1 / stats.GetAttackSpeed())
            {
                if (stopToAttack) { path.SetMoveState(false); }

                attackTimer = 0;
                target.GetComponent<UnitStats>().Damage(stats.GetAttackDamage(), stats.GetEmpire());

                Invoke(nameof(RestartMove), 0.15f);
            }
        }
        else
        {
            path.SetMoveState(true);
            attackTimer = 0;
        }
    }

    public void SetTarget(Collider2D collision)
    {
        if (!collision) { target = null; }
        else if (!target) { target = collision.gameObject; }
    }

    void RestartMove() { path.SetMoveState(true); }

    GameObject GetCorrectParent(Transform child)
    {
        return child.parent.parent.gameObject;
    }
}
