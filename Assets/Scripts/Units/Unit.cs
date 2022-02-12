using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Custom/Unit")]
public class Unit : ScriptableObject
{
    [SerializeField] private string unitName;
    [SerializeField] private UnitEmpire empire;
    [SerializeField] private RomeType type;
    [SerializeField] private RomeWeapon weapon;
    [SerializeField] private RomeHelmet helmet;
    [SerializeField] private RomeArmor armor;
    [SerializeField] private List<RomeTrait> traits;

    private bool isRanged = false;

    public UnitEmpire GetUnitEmpire() { return empire; }
    public RomeType GetUnitType() { return type; }
    public RomeWeapon GetUnitWeapon() { return weapon; }
    public RomeHelmet GetUnitHelmet() { return helmet; }
    public RomeArmor GetUnitArmor() { return armor; }
    public List<RomeTrait> GetUnitTraits() { return traits; }

    public void SetRanged(bool state) { isRanged = state; }
    public bool IsRanged() { return isRanged; }
}
