using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDetector : MonoBehaviour
{
    private EnemyAttack attack;

    private void Awake()
    {
        attack = GetComponentInParent<EnemyAttack>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        attack.SetTarget(collision);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        attack.SetTarget(null);
    }
}
