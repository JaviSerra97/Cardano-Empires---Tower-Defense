using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnitOnCell : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject removeButton;
    private bool isButtonActive;

    [SerializeField] private LayerMask unitLayer;

    private Transform attackRange;

    private bool isPlaced = false;
    private bool setDirection = false;
    private bool settingDirection = false;

    private Vector3 pos;

    private GridCell cell;

    private SpriteRenderer spriteRenderer;

    private bool hasMousePos = false;

    private UnitAbility ability;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ability = GetComponent<UnitAbility>();
    }

    private void Start()
    {
        LevelManager.Instance.SetPlacingUnit(this);
    }

    private void Update()
    {
        if(!attackRange && transform.childCount > 0) { attackRange = transform.GetChild(transform.childCount - 1); }

        if (!isPlaced)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);

            if (Input.GetMouseButtonUp(0))
            {
                if (LevelManager.Instance.IsCellSelected())
                {
                    isPlaced = true;
                    LevelManager.Instance.SetUnitOnCell(this.gameObject);
                    cell = LevelManager.Instance.GetSelectedCell();
                    setDirection = true;
                }
                else 
                {
                    //LevelManager.Instance.IsPlacingUnit(false);
                    //LevelManager.Instance.SetNormalColorCells();
                    DestroyUnit();
                }
            }
        }
        else if (setDirection)
        {
            if (!hasMousePos) 
            {
                hasMousePos = true;
                pos = Input.mousePosition;
                settingDirection = true;
            }

            if (settingDirection)
            {
                CheckDirection(pos);

                if (Input.GetMouseButtonDown(0))
                {
                    LevelManager.Instance.SetUnitDirection();

                    foreach (Transform child in attackRange)
                    {
                        child.GetComponent<Collider2D>().enabled = true;
                    }

                    setDirection = false;
                    ShowRange(false);

                    ability.enabled = true;
                    ability.SetRangePosition(pos);
                }

                if (Input.GetMouseButtonDown(1)) 
                {
                    DestroyUnit();
                    //LevelManager.Instance.IsPlacingUnit(false);
                    //LevelManager.Instance.SetNormalColorCells();
                }
            }
        }

        if(isPlaced && !setDirection)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!isButtonActive)
                {
                    var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.right, 0.1f, unitLayer);

                    if (hit.transform == transform)
                    {
                        removeButton.SetActive(true);
                        isButtonActive = true;
                    }
                }
                else
                {
                    removeButton.SetActive(false);
                    isButtonActive = false;
                }
            }
        }
    }

    void CheckDirection(Vector3 pos)
    {
        Vector3 currentPos = Input.mousePosition - pos;

        if(Mathf.Abs(currentPos.x) > Mathf.Abs(currentPos.y))
        {
            if(currentPos.x > 0) { attackRange.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); spriteRenderer.flipX = false; }//Right
            else if(currentPos.x < 0) { attackRange.rotation = Quaternion.Euler(new Vector3(0, 0, 180)); spriteRenderer.flipX = true; }//Left
        }
        if(Mathf.Abs(currentPos.x) < Mathf.Abs(currentPos.y))
        {
            if (currentPos.y > 0) { attackRange.rotation = Quaternion.Euler(new Vector3(0, 0, 90)); spriteRenderer.flipX = false; }//Up
            else if (currentPos.y < 0) { attackRange.rotation = Quaternion.Euler(new Vector3(0, 0, 270)); spriteRenderer.flipX = true; }//Down
        }
    }

    public void ShowRange(bool state) 
    {
        if (!setDirection) 
        {
            foreach(Transform child in attackRange)
            {
                child.GetComponent<SpriteRenderer>().enabled = state;
            }
        } 
    }

    public void DestroyUnit()
    {
        //LevelManager.Instance.SetUnitOnCell(null);
        //LevelManager.Instance.SetPlacingUnit(null);
        //LevelManager.Instance.IsPlacingUnit(true);
        LevelManager.Instance.IsPlacingUnit(false);
        LevelManager.Instance.SetNormalColorCells();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (cell) { cell.UnitPlaced(false); }
    }

}
