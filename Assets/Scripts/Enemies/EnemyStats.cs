using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;
using DG.Tweening;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private UnitEmpire enemyEmpire;

    [Header("Stats")]
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float baseAttackDamage;
    [SerializeField] private float baseAttackSpeed;
    [SerializeField] private float baseDefense;
    [SerializeField] private float baseAbilityDefense;

    private float currentHealth;
    private float currentMoveSpeed;
    private float currentAttackDamage;
    private float currentAttackSpeed;
    private float currentDefense;
    private float currentAbilityDefense;

    private SpriteRenderer spriteRenderer;

    private HealthBar healthBar;

    private EnemyPath path;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<HealthBar>();
        path = GetComponent<EnemyPath>();
    }

    private void Start()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        currentHealth = baseHealth;
        currentMoveSpeed = baseMoveSpeed;
        currentAttackDamage = baseAttackDamage;
        currentAttackSpeed = baseAttackSpeed;
        currentDefense = baseDefense;
        currentAbilityDefense = baseAbilityDefense;

        path.SetMoveSpeed(currentMoveSpeed);
    }

    public void Damage(float dmg, string empire)
    {

        currentHealth -= CalculateDamage(dmg, empire);

        Debug.Log(CalculateDamage(dmg, empire));

        //transform.DOShakePosition(0.15f, 0.15f).Play();
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
        return empire == enemyEmpire.ToString(); ;
    }

    private void CheckCurrentHealth()
    {
        if (currentHealth <= 0)
        {
            //WavesManager.Instance.RemoveEnemy(gameObject);
            Destroy(gameObject, 0.25f);
        }
    }

    #region DEBUFFS

    public void MoveSpeedDebuff(float amount, float duration)
    {
        path.SetMoveSpeed(currentMoveSpeed * amount);

        Invoke(nameof(RestoreMoveSpeed), duration);
    }

    void RestoreMoveSpeed() { path.SetMoveSpeed(currentMoveSpeed); }

    #endregion

    #region GET STATS
    public string GetEmpire() { return enemyEmpire.ToString(); }
    public float GetHealth() { return currentHealth; }
    public float GetAttackDamage() { return currentAttackDamage; }
    public float GetAttackSpeed() { return currentAttackSpeed; }
    public float GetDefense() { return currentDefense; }
    public float GetAbilityDefense() { return currentAbilityDefense; }
    #endregion

}
