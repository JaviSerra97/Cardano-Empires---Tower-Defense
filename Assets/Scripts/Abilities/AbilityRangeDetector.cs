using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRangeDetector : MonoBehaviour
{
    private UnitAbility unit;

    private void Awake()
    {
        unit = GetComponentInParent<UnitAbility>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unit.AddEnemy(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        unit.RemoveEnemy(collision.gameObject);
    }

    private void OnDisable()
    {
        if (unit) { unit.ClearEnemiesList(); }
    }
}
