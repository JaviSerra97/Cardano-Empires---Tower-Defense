using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private Path path;

    private float moveSpeed;

    private GridCell currentTarget;
    private int targetIndex = 0;

    private bool canMove;
    private bool isMoving;

    private void Awake()
    {
        var listOfPaths = FindObjectsOfType<Path>();
        foreach (var p in listOfPaths)
        {
            Debug.Log(p.name);
            if (p.CheckEnemies(gameObject))
            {
                path = p;
                return;
            }
        }

        Debug.Log("Sin path asignado");
        Destroy(gameObject);
    }

    private void Start()
    {
        currentTarget = path.pathList[0];

        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position,
                moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentTarget.transform.position) < 0.05f)
            {
                SetNextTarget();
            }
        }
    }

    void SetNextTarget()
    {
        if (targetIndex < path.pathList.Count - 1)
        {
            targetIndex++;
            currentTarget = path.pathList[targetIndex];
        }
        else
        {
            Debug.Log("LLegue al final");
            Destroy(gameObject, 1f);
        }
    }

    public void SetMoveState(bool state)
    {
        canMove = state;
    }

    public void SetMoveSpeed(float spd)
    {
        moveSpeed = spd;
    }

}
