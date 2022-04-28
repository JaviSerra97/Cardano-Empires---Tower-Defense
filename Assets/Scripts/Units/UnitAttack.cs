using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private List<UnityEngine.GameObject> enemiesOnRange;

    [SerializeField] private UnityEngine.GameObject attackEffect;

    private float attackTimer;

    private UnitStats stats;

    private void Awake()
    {
        stats = GetComponent<UnitStats>();
    }

    private void Update()
    {
        if(enemiesOnRange.Count > 0 && enemiesOnRange[0] != null)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 1 / stats.GetAttackSpeed())
            {
                attackTimer = 0;
                enemiesOnRange[0].GetComponent<EnemyStats>().Damage(stats.GetAttackDamage(), stats.GetEmpire());
                ShowAttackEffect();
            }
        }
        else { enemiesOnRange.Clear(); }
    }

    void AddEnemy(UnityEngine.GameObject enemy) 
    { 
        enemiesOnRange.Add(enemy);
    }

    void RemoveEnemy(UnityEngine.GameObject enemy) { enemiesOnRange.Remove(enemy); }

    void ShowAttackEffect()
    {
        attackEffect.transform.position = enemiesOnRange[0].transform.position;
        attackEffect.SetActive(true);
    }

    public void SetTarget(Collider2D collision)
    {
        if (!enemiesOnRange.Contains(collision.gameObject)) { AddEnemy(collision.gameObject); }
    }

    public void Removetarget(Collider2D collision) 
    {
        RemoveEnemy(collision.gameObject);
    }
}
