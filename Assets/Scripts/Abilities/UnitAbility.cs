using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;
public class UnitAbility : MonoBehaviour
{
    [SerializeField] private Ability ability;
    [SerializeField] private LayerMask raycastLayer;

    private bool isReady = false;
    private bool showRange = false;
    private float timer;

    [SerializeField] private List<GameObject> listOfEnemies;

    private AbilityBar abilityBar;

    private GameObject range;

    private UnitStats stats;

    private void Awake()
    {
        abilityBar = GetComponentInChildren<AbilityBar>();
        stats = GetComponent<UnitStats>();
    }

    private void Update()
    {
        if (showRange)
        {
            if (Input.GetMouseButtonDown(0)) //Use ability.
            {
                Debug.Log("Use: " + ability.id);
                UseAbility();
            }

            if(Input.GetMouseButtonDown(1)) //Cancel use.
            {
                ShowRange(false);
                Debug.Log("Ability canceled");
            }
        }

        if (!isReady)
        {
            timer += Time.deltaTime;

            abilityBar.UpdateAbilityBar(timer, ability.abilityCooldown);

            if(timer >= ability.abilityCooldown) 
            {
                isReady = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //Show ability range when can be used.
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.right, 0.1f, raycastLayer);

                if (hit.transform == transform) 
                {
                    ShowRange(true);
                }
            }
        }        
    }

    public void SetRangePosition(Vector3 pos)
    {
        if (ability.abilityRange)
        {
            range = Instantiate(ability.abilityRange, transform.position, transform.rotation, transform);

            Vector3 currentPos = Input.mousePosition - pos;

            if (Mathf.Abs(currentPos.x) > Mathf.Abs(currentPos.y))
            {
                if (currentPos.x > 0) { range.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); }//Right
                else if (currentPos.x < 0) { range.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180)); }//Left
            }
            if (Mathf.Abs(currentPos.x) < Mathf.Abs(currentPos.y))
            {
                if (currentPos.y > 0) { range.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90)); }//Up
                else if (currentPos.y < 0) { range.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270)); }//Down
            }

            ShowRange(false);
        }
    }

    void ShowRange(bool state)
    {
        if (range)
        {
            foreach (Transform child in range.transform)
            {
                child.gameObject.SetActive(state);
            }
        }

        showRange = state;
    }

    void UseAbility()
    {
        switch (ability.target)
        {
            case AbilityTarget.Allies:             
                return;

            case AbilityTarget.Enemies:

                if(ability.range == AbilityRange.Target)
                {
                    RestartAbilityUse();
                }
                else if(ability.range == AbilityRange.Range)
                {
                    foreach(GameObject e in listOfEnemies)
                    {
                        EnemyStats s = e.GetComponent<EnemyStats>();
                        s.Damage(CalculateAbilityDamage(), stats.GetEmpire());
                        ApplyBuffs(s);
                    }

                    RestartAbilityUse();
                }
                else if(ability.range == AbilityRange.Global)
                {
                    GameObject[] enemiesOnScene = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach(GameObject e in enemiesOnScene)
                    {
                        EnemyStats s = e.GetComponent<EnemyStats>();
                        s.Damage(CalculateAbilityDamage(), stats.GetEmpire());
                        ApplyBuffs(s);
                    }

                    RestartAbilityUse();
                }

                return;

            case AbilityTarget.Global:
                return;
        }
    }

    void RestartAbilityUse()
    {
        timer = 0;
        isReady = false;
        ShowRange(false);
    }

    public void AddEnemy(GameObject e) 
    {
        if (!listOfEnemies.Contains(e)) { listOfEnemies.Add(e); }
    }

    public void RemoveEnemy(GameObject e) { listOfEnemies.Remove(e); }

    public void ClearEnemiesList() { listOfEnemies.Clear(); }

    float CalculateAbilityDamage()
    {
        switch (ability.damage.damageType)
        {
            case DamageType.None:
                return 0;

            case DamageType.FixedAmount:
                return ability.damage.amount;

            case DamageType.Multiplier:
                return stats.GetAttackDamage() * ability.damage.amount;

            default:
                return 0;
        }
    }

    void ApplyBuffs(EnemyStats s)
    {
        foreach (Buff b in ability.buffsList)
        {
            switch (b.stat)
            {
                case Stats.MoveSpeed:
                    s.MoveSpeedDebuff(b.modifier, b.duration);
                    return;
            }
        }
    }
}
