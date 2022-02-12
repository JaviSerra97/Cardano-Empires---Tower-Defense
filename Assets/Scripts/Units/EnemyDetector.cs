using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private UnitAttack attack;

    private void Awake()
    {
        attack = GetComponentInParent<UnitAttack>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        attack.SetTarget(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attack.Removetarget(collision);
    }
}
