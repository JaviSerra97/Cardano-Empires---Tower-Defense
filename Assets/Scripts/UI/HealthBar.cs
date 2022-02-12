using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthFill;

    public void UpdateHealthBar(float current, float total)
    {
        healthFill.fillAmount = current / total;
    }
}
