
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class UnitStats : MonoBehaviour
{
    private Unit unit;

    private float baseHealth;
    private float baseAttackDamage;
    private float baseAttackSpeed;
    private float baseDefense;
    private float baseAbilityDefense;

    private float currentHealth;
    private float currentAttackDamage;
    private float currentAttackSpeed;
    private float currentDefense;
    private float currentAbilityDefense;

    private SpriteRenderer spriteRenderer;

    private HealthBar healthBar;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void InitializeStats()
    {
        currentHealth = baseHealth;
        currentAttackDamage = baseAttackDamage;
        currentAttackSpeed = baseAttackSpeed;
        currentDefense = baseDefense;
        currentAbilityDefense = baseAbilityDefense;
    }

    public void AddStats(float hp, float dmg, float asp, float def, float adef)
    {
        baseHealth += hp;
        baseAttackDamage += dmg;
        baseAttackSpeed += asp;
        baseDefense += def;
        baseAbilityDefense += adef;
    }

    public void SetUnit(Unit u) 
    {
        unit = u;

        RomeInitializer.Instance.InitializeUnit(this);
        InitializeStats();
    }

    public Unit GetUnit() { return unit; }

    public void Damage(float dmg, string empire)
    {       
        currentHealth -= CalculateDamage(dmg, empire);

        transform.DOShakePosition(0.15f, 0.15f).Play();
        spriteRenderer.color = Color.grey;
        spriteRenderer.DOColor(Color.white, 0.25f).Play();

        if (healthBar) { healthBar.UpdateHealthBar(currentHealth, baseHealth); }

        CheckCurrentHealth();
    }

    float CalculateDamage(float dmg, string empire)
    {
        float e = 1f;
        if (CheckType(empire)) { e = 1.5f; }

        return (0.01f * Random.Range(85, 100) * e * ((10 * dmg) / (2 * currentDefense)));
    }

    bool CheckType(string empire)
    {
        return empire == unit.GetUnitEmpire().ToString();
    }

    private void CheckCurrentHealth()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject, 0.25f);
        }
    }

    #region GET STATS
    public string GetEmpire() { return unit.GetUnitEmpire().ToString(); }
    public float GetHealth() { return currentHealth; }
    public float GetAttackDamage() { return currentAttackDamage; }
    public float GetAttackSpeed() { return currentAttackSpeed; }
    public float GetDefense() { return currentDefense; }
    public float GetAbilityDefense() { return currentAbilityDefense; }
    #endregion
}
