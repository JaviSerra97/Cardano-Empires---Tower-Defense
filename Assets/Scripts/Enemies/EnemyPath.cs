using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<GridCell> pathList;

    [SerializeField] private float moveSpeed;

    private GridCell currentTarget;
    private int targetIndex = 0;

    private bool canMove;
    private bool isMoving;

    [Header("Gizmos")]
    [SerializeField] private Color pathColor;

    private void Start()
    {
        currentTarget = pathList[0];

        canMove = true;
    }

    private void Update()
    {   
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);

            if(Vector3.Distance(transform.position, currentTarget.transform.position) < 0.05f) { SetNextTarget(); }
        }
    }

    void SetNextTarget()
    {
        if (targetIndex < pathList.Count - 1)
        {
            targetIndex++;
            currentTarget = pathList[targetIndex];
        }
    }

    public void SetMoveState(bool state) { canMove = state; }
    
    public void SetMoveSpeed(float spd) { moveSpeed = spd; }


    #region GIZMOS

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(pathList[0].transform.position, 0.15f);
        Gizmos.DrawSphere(pathList[pathList.Count - 1].transform.position, 0.15f);

        Gizmos.color = pathColor;
        for(int i = 0; i < pathList.Count - 1; i++)
        {
            Gizmos.DrawLine(pathList[i].transform.position, pathList[i + 1].transform.position);
        }
    }

    #endregion
}
