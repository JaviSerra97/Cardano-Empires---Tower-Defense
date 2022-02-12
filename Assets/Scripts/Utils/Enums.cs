using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum UnitEmpire { Rome};

    #region ROME

    public enum RomeType { Soldier, Emperor, EmperorCH, God};
    public enum RomeWeapon 
    { 
        CommonSword, RareSword, EpicSword, LegendarySword,
        CommonSpear, RareSpear, EpicSpear, LegendarySpear,
        CommonBow, Crossbow, EpicBow, LegendaryCrossbow,
        AmberSword, AmethystSword, EmeraldSword, RubySword, SapphireSword
    };
    public enum RomeHelmet
    {
        CommonHelmet, RareHelmet, EpicHelmet, LegendaryHelmet,
        BlueCrown, GreenCrown, PurpleCrown, RedCrown, YellowCrown
    };
    public enum RomeArmor { Armor, LinteaArmor, SquamataArmor, HamataArmor, SegmentataArmor, WhiteMoonArmor };
    public enum RomeTrait 
    {
        CommonShield, RareShield, EpicShield, LegendaryShield, 
        Cloak, 
        BlueCardano, PinkCardano, RedCardano, WhiteCardano, YellowCardano, 
        RareBoots, EpicBoots, 
        CloudyBackground, DayBackground, NightBackground, SunsetBackground,
        Bracelet,
        RareScepter, EpicScepter,
        RareJar, EpicJar,
        BlueBanner, GreenBanner, PurpleBanner, RedBanner, WhiteBanner,
        Bird,
        Calceus
    };

    #endregion

    #region STATS

    public enum Stats { MoveSpeed, AttackSpeed, AttackDamage, Defense, AbilityDefense, AbilityCooldown }

    public enum DamageType { None, FixedAmount, Multiplier}

    #endregion

    #region ABILITIES

    public enum AbilityRarity { Common, Rare, Epic, Legendary };
    public enum AbilityTarget {Enemies, Allies, Global};
    public enum AbilityRange {Target, Range, Global};

    #endregion
}
