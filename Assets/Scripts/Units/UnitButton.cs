using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnityEngine.GameObject unitBlueprint;
    [SerializeField] private Transform unitsParent;

    [SerializeField] private KeyCode keyToInvoke;

    private void Update()
    {
        if (Input.GetKeyDown(keyToInvoke))
        {
            OnUnitButtonPressed();
        }
    }

    public void OnUnitButtonPressed()
    {
        if (!LevelManager.Instance.IsPlacingUnit())
        {
            if (!unit.IsRanged()) { LevelManager.Instance.ShowMeleeAvailableCells(); }

            if (unit.IsRanged()) { LevelManager.Instance.ShowRangedAvailableCells(); }

            var u = Instantiate(unitBlueprint, Input.mousePosition, Quaternion.identity, unitsParent);
            u.GetComponent<UnitStats>().SetUnit(unit);

            LevelManager.Instance.IsPlacingUnit(true);
        }
    }

    public void SetKey(int i)
    {
        keyToInvoke = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i.ToString());
    }
}
