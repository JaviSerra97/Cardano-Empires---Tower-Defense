using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "New Ability", menuName = "Custom/Ability")]
public class Ability : ScriptableObject
{
    public string id;
    public AbilityRange range;
    public AbilityTarget target;
    public UnityEngine.GameObject abilityRange;
    public Damage damage;
    public float abilityCooldown;
    public List<Buff> buffsList;
    public AbilityRarity rarity;
}

[System.Serializable]
public class Damage
{
    public DamageType damageType;
    public float amount;
}

[System.Serializable]
public class Buff
{
    public string id;
    public Stats stat;
    public float modifier;
    public float duration;
    [Tooltip("If TRUE, buff affects the unit too")]
    public bool autoEffect;
}
