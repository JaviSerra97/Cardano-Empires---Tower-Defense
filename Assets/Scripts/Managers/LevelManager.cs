using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private LayerMask gridLayer;
    private Collider2D lastGridSelected;

    [Header("Units Lists")]
    [SerializeField] private List<GridCell> MeleeGridList;
    [SerializeField] private List<GridCell> RangedGridList;

    [Header("Cell Colors")]
    [SerializeField] private Color normalColor;
    [SerializeField] private Color placeableColor;
    [SerializeField] private Color hoverColor;

    private GridCell selectedCell;
    private PlaceUnitOnCell placingUnit;
    private bool isPlacingUnit = false;

    public void AddToMeleeGrid(GridCell cell) { MeleeGridList.Add(cell); }
    public void AddToRangeGrid(GridCell cell) { RangedGridList.Add(cell); }

    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.right, 0.1f, gridLayer);

        if (hit.collider) 
        {
            if(lastGridSelected && lastGridSelected != hit.collider) { lastGridSelected.GetComponent<GridCell>().CheckMouseExit(); }

            hit.transform.GetComponent<GridCell>().CheckMouseOver();
            lastGridSelected = hit.collider;
        }        
    }

    #region PLACING_UNITS
    public void ShowMeleeAvailableCells()
    {
        foreach(GridCell cell in MeleeGridList)
        {
            cell.SetColor(placeableColor);
            cell.CanPlaceUnit(true);
        }
    }

    public void ShowRangedAvailableCells()
    {
        foreach (GridCell cell in RangedGridList)
        {
            cell.SetColor(placeableColor);
            cell.CanPlaceUnit(true);
        }
    }

    public void SetNormalColorCells()
    {
        foreach(GridCell cell in MeleeGridList) 
        {
            cell.SetColor(normalColor); 
            cell.CanPlaceUnit(false);
        }
        foreach(GridCell cell in RangedGridList) 
        {
            cell.SetColor(normalColor);
            cell.CanPlaceUnit(false);
        }
    }

    void SetHoverCellColor(GridCell cell) 
    {
        cell.SetColor(hoverColor);
        ShowUnitRange(true);
    }

    public void QuitHoverCellColor(GridCell cell) 
    {
        cell.SetColor(placeableColor);
        SetSelectedCell(null);
        ShowUnitRange(false);
    }

    public void IsPlacingUnit(bool state) { isPlacingUnit = state; }

    public bool IsPlacingUnit() { return isPlacingUnit; }

    public void SetSelectedCell(GridCell cell) 
    {
        selectedCell = cell;
        if (cell) { SetHoverCellColor(cell); }
    }

    public bool IsCellSelected() { return selectedCell; }

    public GridCell GetSelectedCell() { return selectedCell; }

    public void SetUnitOnCell(GameObject unit) 
    {
        unit.transform.position = selectedCell.transform.position;
        selectedCell.UnitPlaced(true);
        IsPlacingUnit(false);
    }

    public void SetPlacingUnit(PlaceUnitOnCell unit) { placingUnit = unit; }

    public void SetUnitDirection()
    {
        SetNormalColorCells();
    }

    void ShowUnitRange(bool state)
    {
        placingUnit.ShowRange(state);
    }

    #endregion
}
