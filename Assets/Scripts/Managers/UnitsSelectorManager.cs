using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

public class UnitsSelectorManager : Singleton<UnitsSelectorManager>
{
    [SerializeField] private Transform selectedLayout;
    [SerializeField] private List<GameObject> selectedTeam;

    [SerializeField] private int teamCapacity;
    private int currentOccupation = 0;

    public void OnButtonPressed()
    {
        GameObject unit = EventSystem.current.currentSelectedGameObject.gameObject;
        SelectableUnit u = unit.GetComponent<SelectableUnit>();
        if (u)
        {
            if (!u.IsSelected() && CheckCapacity(5))
            {
                GameObject go = Instantiate(unit, selectedLayout);
                selectedTeam.Add(go);
                go.AddComponent<SelectedUnit>();
                Destroy(go.GetComponent<SelectableUnit>());
                go.GetComponent<SelectedUnit>().SetUnitReference(unit);

                u.SetSelectionState(true);

                AddOccupation(5);
            }
        }
        else { Destroy(unit);}
    }

    public void RemoveFromTeam(GameObject go) 
    {
        if (selectedTeam.Contains(go)) 
        {
            selectedTeam.Remove(go);
            RemoveOccupation(5);
        } 
    }

    public void AddOccupation(int c) { currentOccupation += c; }
    public void RemoveOccupation(int c) { currentOccupation -= c; }
    public bool CheckCapacity(int c)
    {
        if (currentOccupation + c > teamCapacity) { return false; }
        else { return true; }
    }
}
