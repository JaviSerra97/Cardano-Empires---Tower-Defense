using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSpeed : MonoBehaviour
{
    [SerializeField] private int maxSpeed;
    [SerializeField] private TMP_Text speedText;

    private int currentSpeed;

    private void Start()
    {
        currentSpeed = 1;
        speedText.text = "x" + currentSpeed;
    }

    public void ChangeSpeed()
    {
        if(currentSpeed < maxSpeed) { currentSpeed++; }
        else { currentSpeed = 1; }

        speedText.text = "x" + currentSpeed;

        Time.timeScale = currentSpeed;
    }
}
