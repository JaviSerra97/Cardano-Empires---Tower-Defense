using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using static Enums;

public class RomeInitializer : Singleton<RomeInitializer>
{
    [System.Serializable]
    class EquipmentStats
    {
        public float health;
        public float attackDamage;
        public float attackSpeed;
        public float defense;
        public float abilityDefense;
    }

    [Header("Unit Type Stats")]
    [SerializeField] private EquipmentStats soldier;
    [SerializeField] private EquipmentStats emperor;
    [SerializeField] private EquipmentStats emperorCH;
    [SerializeField] private EquipmentStats god;

    [Header("Unit Weapon Stats")]
    [SerializeField] private EquipmentStats commonSword;
    [SerializeField] private EquipmentStats rareSword;
    [SerializeField] private EquipmentStats epicSword;
    [SerializeField] private EquipmentStats legendarySword;
    [SerializeField] private EquipmentStats commonSpear;
    [SerializeField] private EquipmentStats rareSpear;
    [SerializeField] private EquipmentStats epicSpear;
    [SerializeField] private EquipmentStats legendarySpear;
    [SerializeField] private EquipmentStats commonBow;
    [SerializeField] private EquipmentStats crossbow;
    [SerializeField] private EquipmentStats epicBow;
    [SerializeField] private EquipmentStats legendaryCrossbow;
    [SerializeField] private EquipmentStats amberSword;
    [SerializeField] private EquipmentStats amethystSword;
    [SerializeField] private EquipmentStats rubySword;
    [SerializeField] private EquipmentStats saphireSword;
    [SerializeField] private EquipmentStats emeraldSword;

    [Header("Unit Helmet Stats")]
    [SerializeField] private EquipmentStats commonHelmet;
    [SerializeField] private EquipmentStats rareHelmet;
    [SerializeField] private EquipmentStats epicHelmet;
    [SerializeField] private EquipmentStats legenaryHelmet;
    [SerializeField] private EquipmentStats blueCrown;
    [SerializeField] private EquipmentStats greenCrown;
    [SerializeField] private EquipmentStats purpleCrown;
    [SerializeField] private EquipmentStats redCrown;
    [SerializeField] private EquipmentStats yellowCrown;

    [Header("Unit Armor Stats")]
    [SerializeField] private EquipmentStats armor;
    [SerializeField] private EquipmentStats linteaArmor;
    [SerializeField] private EquipmentStats squamataArmor;
    [SerializeField] private EquipmentStats hamataArmor;
    [SerializeField] private EquipmentStats segmentataArmor;

    [Header("Unit Trait Stats")]
    [SerializeField] private EquipmentStats commonShield;
    [SerializeField] private EquipmentStats rareShield;
    [SerializeField] private EquipmentStats epicShield;
    [SerializeField] private EquipmentStats legendaryShield;
    [SerializeField] private EquipmentStats cloak;
    [SerializeField] private EquipmentStats blueCardano;
    [SerializeField] private EquipmentStats pinkCardano;
    [SerializeField] private EquipmentStats redCardano;
    [SerializeField] private EquipmentStats whiteCardano;
    [SerializeField] private EquipmentStats yellowCardano;
    [SerializeField] private EquipmentStats rareBoots;
    [SerializeField] private EquipmentStats epicBoots;
    [SerializeField] private EquipmentStats cloudyBackground;
    [SerializeField] private EquipmentStats dayBackground;
    [SerializeField] private EquipmentStats nightBackground;
    [SerializeField] private EquipmentStats sunsetBackground;
    [SerializeField] private EquipmentStats bracelet;
    [SerializeField] private EquipmentStats rareScepter;
    [SerializeField] private EquipmentStats epicScepter;
    [SerializeField] private EquipmentStats rareJar;
    [SerializeField] private EquipmentStats epicJar;
    [SerializeField] private EquipmentStats blueBanner;
    [SerializeField] private EquipmentStats greenBanner;
    [SerializeField] private EquipmentStats purpleBanner;
    [SerializeField] private EquipmentStats redBanner;
    [SerializeField] private EquipmentStats whiteBanner;
    [SerializeField] private EquipmentStats bird;
    [SerializeField] private EquipmentStats calceus;

    [Header("Attack Ranges")]
    [SerializeField] private UnityEngine.GameObject swordRange;
    [SerializeField] private UnityEngine.GameObject stoneSwordRange;
    [SerializeField] private UnityEngine.GameObject bowRange;
    [SerializeField] private UnityEngine.GameObject spearRange;


    public void InitializeUnit(UnitStats u)
    {
        InitializeType(u);
        InitializeWeapon(u);
        InitializeHelmet(u);
        InitializeArmor(u);
        InitializeTraits(u);
    }

    void InitializeType(UnitStats u)
    {
        Unit unit = u.GetUnit();

        switch (unit.GetUnitType())
        {
            case RomeType.Soldier:
                u.AddStats(soldier.health, soldier.attackDamage, soldier.attackSpeed, soldier.defense, soldier.abilityDefense);
                break;

            case RomeType.Emperor:
                u.AddStats(emperor.health, emperor.attackDamage, emperor.attackSpeed, emperor.defense, emperor.abilityDefense);
                break;

            case RomeType.EmperorCH:
                u.AddStats(emperorCH.health, emperorCH.attackDamage, emperorCH.attackSpeed, emperorCH.defense, emperorCH.abilityDefense);
                break;

            case RomeType.God:
                u.AddStats(god.health, god.attackDamage, god.attackSpeed, god.defense, god.abilityDefense);
                break;
        }
    }

    void InitializeWeapon(UnitStats u)
    {
        Unit unit = u.GetUnit();

        switch (unit.GetUnitWeapon())
        {
            case RomeWeapon.CommonSword:
                u.AddStats(commonSword.health, commonSword.attackDamage, commonSword.attackSpeed, commonSword.defense, commonSword.abilityDefense);
                Instantiate(swordRange, u.transform);
                break;

            case RomeWeapon.RareSword:
                u.AddStats(rareSword.health, rareSword.attackDamage, rareSword.attackSpeed, rareSword.defense, rareSword.abilityDefense);
                Instantiate(swordRange, u.transform);
                break;

            case RomeWeapon.EpicSword:
                u.AddStats(epicSword.health, epicSword.attackDamage, epicSword.attackSpeed, epicSword.defense, epicSword.abilityDefense);
                Instantiate(swordRange, u.transform);
                break;

            case RomeWeapon.LegendarySword:
                u.AddStats(legendarySword.health, legendarySword.attackDamage, legendarySword.attackSpeed, legendarySword.defense, legendarySword.abilityDefense);
                Instantiate(swordRange, u.transform);
                break;

            case RomeWeapon.CommonSpear:
                u.AddStats(commonSpear.health, commonSpear.attackDamage, commonSpear.attackSpeed, commonSpear.defense, commonSpear.abilityDefense);
                Instantiate(spearRange, u.transform);
                break;

            case RomeWeapon.RareSpear:
                u.AddStats(rareSpear.health, rareSpear.attackDamage, rareSpear.attackSpeed, rareSpear.defense, rareSpear.abilityDefense);
                Instantiate(spearRange, u.transform);
                break;

            case RomeWeapon.EpicSpear:
                u.AddStats(epicSpear.health, epicSpear.attackDamage, epicSpear.attackSpeed, epicSpear.defense, epicSpear.abilityDefense);
                Instantiate(spearRange, u.transform);
                break;

            case RomeWeapon.LegendarySpear:
                u.AddStats(legendarySpear.health, legendarySpear.attackDamage, legendarySpear.attackSpeed, legendarySpear.defense, legendarySpear.abilityDefense);
                Instantiate(spearRange, u.transform);
                break;

            case RomeWeapon.CommonBow:
                unit.SetRanged(true);
                u.AddStats(commonBow.health, commonBow.attackDamage, commonBow.attackSpeed, commonBow.defense, commonBow.abilityDefense);
                Instantiate(bowRange, u.transform);
                break;

            case RomeWeapon.Crossbow:
                unit.SetRanged(true);
                u.AddStats(crossbow.health, crossbow.attackDamage, crossbow.attackSpeed, crossbow.defense, crossbow.abilityDefense);
                Instantiate(bowRange, u.transform);
                break;

            case RomeWeapon.EpicBow:
                unit.SetRanged(true);
                u.AddStats(epicBow.health, epicBow.attackDamage, epicBow.attackSpeed, epicBow.defense, epicBow.abilityDefense);
                Instantiate(bowRange, u.transform);
                break;

            case RomeWeapon.LegendaryCrossbow:
                unit.SetRanged(true);
                u.AddStats(legendaryCrossbow.health, legendaryCrossbow.attackDamage, legendaryCrossbow.attackSpeed, legendaryCrossbow.defense, legendaryCrossbow.abilityDefense);
                Instantiate(bowRange, u.transform);
                break;

            case RomeWeapon.AmberSword:
                u.AddStats(amberSword.health, amberSword.attackDamage, amberSword.attackSpeed, amberSword.defense, amberSword.abilityDefense);
                Instantiate(stoneSwordRange, u.transform);
                break;

            case RomeWeapon.AmethystSword:
                u.AddStats(amethystSword.health, amethystSword.attackDamage, amethystSword.attackSpeed, amethystSword.defense, amethystSword.abilityDefense);
                Instantiate(stoneSwordRange, u.transform);
                break;

            case RomeWeapon.EmeraldSword:
                u.AddStats(emeraldSword.health, emeraldSword.attackDamage, emeraldSword.attackSpeed, emeraldSword.defense, emeraldSword.abilityDefense);
                Instantiate(stoneSwordRange, u.transform);
                break;

            case RomeWeapon.RubySword:
                u.AddStats(rubySword.health, rubySword.attackDamage, rubySword.attackSpeed, rubySword.defense, rubySword.abilityDefense);
                Instantiate(stoneSwordRange, u.transform);
                break;

            case RomeWeapon.SapphireSword:
                u.AddStats(saphireSword.health, saphireSword.attackDamage, saphireSword.attackSpeed, saphireSword.defense, saphireSword.abilityDefense);
                Instantiate(stoneSwordRange, u.transform);
                break;
        }
    }

    void InitializeHelmet(UnitStats u)
    {
        Unit unit = u.GetUnit();

        switch (unit.GetUnitHelmet())
        {
            case RomeHelmet.CommonHelmet:
                u.AddStats(commonHelmet.health, commonHelmet.attackDamage, commonHelmet.attackSpeed, commonHelmet.defense, commonHelmet.abilityDefense);
                break;

            case RomeHelmet.RareHelmet:
                u.AddStats(rareHelmet.health, rareHelmet.attackDamage, rareHelmet.attackSpeed, rareHelmet.defense, rareHelmet.abilityDefense);
                break;

            case RomeHelmet.EpicHelmet:
                u.AddStats(epicHelmet.health, epicHelmet.attackDamage, epicHelmet.attackSpeed, epicHelmet.defense, epicHelmet.abilityDefense);
                break;

            case RomeHelmet.LegendaryHelmet:
                u.AddStats(legenaryHelmet.health, legenaryHelmet.attackDamage, legenaryHelmet.attackSpeed, legenaryHelmet.defense, legenaryHelmet.abilityDefense);
                break;

            case RomeHelmet.BlueCrown:
                u.AddStats(blueCrown.health, blueCrown.attackDamage, blueCrown.attackSpeed, blueCrown.defense, blueCrown.abilityDefense);
                break;

            case RomeHelmet.GreenCrown:
                u.AddStats(greenCrown.health, greenCrown.attackDamage, greenCrown.attackSpeed, greenCrown.defense, greenCrown.abilityDefense);
                break;

            case RomeHelmet.PurpleCrown:
                u.AddStats(purpleCrown.health, purpleCrown.attackDamage, purpleCrown.attackSpeed, purpleCrown.defense, purpleCrown.abilityDefense);
                break;

            case RomeHelmet.RedCrown:
                u.AddStats(redCrown.health, redCrown.attackDamage, redCrown.attackSpeed, redCrown.defense, redCrown.abilityDefense);
                break;

            case RomeHelmet.YellowCrown:
                u.AddStats(yellowCrown.health, yellowCrown.attackDamage, yellowCrown.attackSpeed, yellowCrown.defense, yellowCrown.abilityDefense);
                break;
        }
    }

    void InitializeArmor(UnitStats u)
    {
        Unit unit = u.GetUnit();

        switch (unit.GetUnitArmor())
        {
            case RomeArmor.Armor:
                u.AddStats(armor.health, armor.attackDamage, armor.attackSpeed, armor.defense, armor.abilityDefense);
                break;

            case RomeArmor.LinteaArmor:
                u.AddStats(linteaArmor.health, linteaArmor.attackDamage, linteaArmor.attackSpeed, linteaArmor.defense, linteaArmor.abilityDefense);
                break;

            case RomeArmor.SquamataArmor:
                u.AddStats(squamataArmor.health, squamataArmor.attackDamage, squamataArmor.attackSpeed, squamataArmor.defense, squamataArmor.abilityDefense);
                break;

            case RomeArmor.HamataArmor:
                u.AddStats(hamataArmor.health, hamataArmor.attackDamage, hamataArmor.attackSpeed, hamataArmor.defense, hamataArmor.abilityDefense);
                break;

            case RomeArmor.SegmentataArmor:
                u.AddStats(segmentataArmor.health, segmentataArmor.attackDamage, segmentataArmor.attackSpeed, segmentataArmor.defense, segmentataArmor.abilityDefense);
                break;
        }
    }

    void InitializeTraits(UnitStats u)
    {
        Unit unit = u.GetUnit();
        var traits = unit.GetUnitTraits();

        foreach (RomeTrait t in traits)
        {
            switch (t)
            {
                case RomeTrait.CommonShield:
                    u.AddStats(commonShield.health, commonShield.attackDamage, commonShield.attackSpeed, commonShield.defense, commonShield.abilityDefense);
                    break;

                case RomeTrait.RareShield:
                    u.AddStats(rareShield.health, rareShield.attackDamage, rareShield.attackSpeed, rareShield.defense, rareShield.abilityDefense);
                    break;

                case RomeTrait.EpicShield:
                    u.AddStats(epicShield.health, epicShield.attackDamage, epicShield.attackSpeed, epicShield.defense, epicShield.abilityDefense);
                    break;

                case RomeTrait.LegendaryShield:
                    u.AddStats(legendaryShield.health, legendaryShield.attackDamage, legendaryShield.attackSpeed, legendaryShield.defense, legendaryShield.abilityDefense);
                    break;

                case RomeTrait.Cloak:
                    u.AddStats(cloak.health, cloak.attackDamage, cloak.attackSpeed, cloak.defense, cloak.abilityDefense);
                    break;

                case RomeTrait.BlueCardano:
                    u.AddStats(blueCardano.health, blueCardano.attackDamage, blueCardano.attackSpeed, blueCardano.defense, blueCardano.abilityDefense);
                    break;

                case RomeTrait.PinkCardano:
                    u.AddStats(pinkCardano.health, pinkCardano.attackDamage, pinkCardano.attackSpeed, pinkCardano.defense, pinkCardano.abilityDefense);
                    break;

                case RomeTrait.RedCardano:
                    u.AddStats(redCardano.health, redCardano.attackDamage, redCardano.attackSpeed, redCardano.defense, redCardano.abilityDefense);
                    break;

                case RomeTrait.WhiteCardano:
                    u.AddStats(whiteCardano.health, whiteCardano.attackDamage, whiteCardano.attackSpeed, whiteCardano.defense, whiteCardano.abilityDefense);
                    break;

                case RomeTrait.YellowCardano:
                    u.AddStats(yellowCardano.health, yellowCardano.attackDamage, yellowCardano.attackSpeed, yellowCardano.defense, yellowCardano.abilityDefense);
                    break;

                case RomeTrait.RareBoots:
                    u.AddStats(rareBoots.health, rareBoots.attackDamage, rareBoots.attackSpeed, rareBoots.defense, rareBoots.abilityDefense);
                    break;

                case RomeTrait.EpicBoots:
                    u.AddStats(epicBoots.health, epicBoots.attackDamage, epicBoots.attackSpeed, epicBoots.defense, epicBoots.abilityDefense);
                    break;

                case RomeTrait.CloudyBackground:
                    u.AddStats(cloudyBackground.health, cloudyBackground.attackDamage, cloudyBackground.attackSpeed, cloudyBackground.defense, cloudyBackground.abilityDefense);
                    break;

                case RomeTrait.DayBackground:
                    u.AddStats(dayBackground.health, dayBackground.attackDamage, dayBackground.attackSpeed, dayBackground.defense, dayBackground.abilityDefense);
                    break;

                case RomeTrait.NightBackground:
                    u.AddStats(nightBackground.health, nightBackground.attackDamage, nightBackground.attackSpeed, nightBackground.defense, nightBackground.abilityDefense);
                    break;

                case RomeTrait.SunsetBackground:
                    u.AddStats(sunsetBackground.health, sunsetBackground.attackDamage, sunsetBackground.attackSpeed, sunsetBackground.defense, sunsetBackground.abilityDefense);
                    break;

                case RomeTrait.Bracelet:
                    u.AddStats(bracelet.health, bracelet.attackDamage, bracelet.attackSpeed, bracelet.defense, bracelet.abilityDefense);
                    break;

                case RomeTrait.RareScepter:
                    u.AddStats(rareScepter.health, rareScepter.attackDamage, rareScepter.attackSpeed, rareScepter.defense, rareScepter.abilityDefense);
                    break;

                case RomeTrait.EpicScepter:
                    u.AddStats(epicScepter.health, epicScepter.attackDamage, epicScepter.attackSpeed, epicScepter.defense, epicScepter.abilityDefense);
                    break;

                case RomeTrait.RareJar:
                    u.AddStats(rareJar.health, rareJar.attackDamage, rareJar.attackSpeed, rareJar.defense, rareJar.abilityDefense);
                    break;

                case RomeTrait.EpicJar:
                    u.AddStats(epicJar.health, epicJar.attackDamage, epicJar.attackSpeed, epicJar.defense, epicJar.abilityDefense);
                    break;

                case RomeTrait.BlueBanner:
                    u.AddStats(blueBanner.health, blueBanner.attackDamage, blueBanner.attackSpeed, blueBanner.defense, blueBanner.abilityDefense);
                    break;

                case RomeTrait.GreenBanner:
                    u.AddStats(greenBanner.health, greenBanner.attackDamage, greenBanner.attackSpeed, greenBanner.defense, greenBanner.abilityDefense);
                    break;

                case RomeTrait.PurpleBanner:
                    u.AddStats(purpleBanner.health, purpleBanner.attackDamage, purpleBanner.attackSpeed, purpleBanner.defense, purpleBanner.abilityDefense);
                    break;

                case RomeTrait.RedBanner:
                    u.AddStats(redBanner.health, redBanner.attackDamage, redBanner.attackSpeed, redBanner.defense, redBanner.abilityDefense);
                    break;

                case RomeTrait.WhiteBanner:
                    u.AddStats(whiteBanner.health, whiteBanner.attackDamage, whiteBanner.attackSpeed, whiteBanner.defense, whiteBanner.abilityDefense);
                    break;

                case RomeTrait.Bird:
                    u.AddStats(bird.health, bird.attackDamage, bird.attackSpeed, bird.defense, bird.abilityDefense);
                    break;

                case RomeTrait.Calceus:
                    u.AddStats(calceus.health, calceus.attackDamage, calceus.attackSpeed, calceus.defense, calceus.abilityDefense);
                    break;
            }
        }
    }
}