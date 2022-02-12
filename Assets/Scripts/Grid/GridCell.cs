using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class GridCell : MonoBehaviour
{
    [Header("Placeable Units")]
    [SerializeField] private bool placeMelee;
    [SerializeField] private bool placeRanged;

    private SpriteRenderer spriteRenderer;

    private bool canPlaceUnit = false;
    private bool showHover = true;
    private bool unitPlaced = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (placeMelee) { LevelManager.Instance.AddToMeleeGrid(this); }

        if (placeRanged) { LevelManager.Instance.AddToRangeGrid(this); }
    }

    public void SetColor(Color col) { spriteRenderer.color = col; }

    public void CanPlaceUnit(bool state)
    {
        if (!unitPlaced)
        {
            canPlaceUnit = state;
            if (!state) { showHover = true; }
        }
        else
        {
            canPlaceUnit = false;
            showHover = false;
        }
    }

    public void UnitPlaced(bool state) 
    {
        unitPlaced = state;
        if (!state) { showHover = true; }
    }

    public void CheckMouseOver()
    {
        if (canPlaceUnit && showHover && LevelManager.Instance.IsPlacingUnit()) 
        {
            LevelManager.Instance.SetSelectedCell(this);
            showHover = false;
        }
    }

    public void CheckMouseExit()
    {
        if (canPlaceUnit) 
        {
            LevelManager.Instance.QuitHoverCellColor(this);
            showHover = true;
        }
    }
}
