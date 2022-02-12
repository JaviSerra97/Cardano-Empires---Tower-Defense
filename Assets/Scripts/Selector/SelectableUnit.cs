using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour
{
    [SerializeField] private bool isSelected;

    private void Start()
    {
        SetSelectionState(false);
    }

    public void SetSelectionState(bool state) { isSelected = state; }

    public bool IsSelected() { return isSelected; }
}
