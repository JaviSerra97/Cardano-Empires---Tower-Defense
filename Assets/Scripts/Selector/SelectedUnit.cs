using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour
{
    [SerializeField] private SelectableUnit unit;
    public void SetUnitReference(UnityEngine.GameObject u) { unit = u.GetComponent<SelectableUnit>(); }

    private void OnDestroy()
    {
        UnitsSelectorManager.Instance.RemoveFromTeam(gameObject);
        unit.SetSelectionState(false);
    }
}
