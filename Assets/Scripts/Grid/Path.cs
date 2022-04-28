using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<GridCell> pathList;
    
    [Tooltip("Prefabs que van a seguir este camino")]
    public List<GameObject> enemies;
    
    [Header("Gizmos")]
    [SerializeField] private Color pathColor;

    public bool CheckEnemies(GameObject e)
    {
        foreach (var p in enemies)
        {
            if (e.name.Equals(p.name + "(Clone)"))
            {
                Debug.Log("Aqui esta");
                return true;
            }
        }

        return false;
    }
    
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
