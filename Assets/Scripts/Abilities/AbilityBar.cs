using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private Image abilityFill;

    public void UpdateAbilityBar(float current, float total)
    {
        abilityFill.fillAmount = current / total;
    }
}
