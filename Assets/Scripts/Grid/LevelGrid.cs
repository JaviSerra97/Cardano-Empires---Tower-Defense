using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private float quadSize;
    [SerializeField] private GridCell[] gridArray;

    private Transform originPosition;

    private void Start()
    {
        //CreateGrid();
    }

    /*
    void CreateGrid()
    {
        originPosition = transform.GetChild(0);

        for(int i = 0; i < gridArray.Length; i++)
        {
            Transform child = transform.GetChild(i);
            child.transform.position = originPosition.position + new Vector3(gridArray[i].GetColumn(), gridArray[i].GetRow()) * quadSize;

            if (gridArray[i].IsLastQuad()) { child.GetComponent<SpriteRenderer>().color = Color.blue; }

            if (gridArray[i].CanPlaceMelee()) { LevelManager.Instance.AddToMeleeGrid(gridArray[i]); }
            if (gridArray[i].CanPlaceRanged()) { LevelManager.Instance.AddToRangeGrid(gridArray[i]); }

            child.gameObject.SetActive(true);
        }
    }*/
}
