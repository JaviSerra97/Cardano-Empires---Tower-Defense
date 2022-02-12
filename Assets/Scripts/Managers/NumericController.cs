using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericController : MonoBehaviour
{
    public Transform buttonsContainer;

    private void Start()
    {
        SetButtonReferencies();
    }

    public void SetButtonReferencies()
    {
        int i = 1;
        foreach (Transform child in buttonsContainer)
        {
            child.GetComponent<UnitButton>().SetKey(i);
            i++;
        }
    }
}
