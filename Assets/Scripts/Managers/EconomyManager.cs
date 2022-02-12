using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    [SerializeField] private float startingGold;
    [SerializeField] private float goldAdditionPerSecond;
    [SerializeField] [Range(0f,1f)] private float refundValue;

    [SerializeField] private TMP_Text goldText;

    private float currentGold;

    private void Start()
    {
        currentGold = startingGold;

        UpdateGoldText();

        StartCoroutine(AddGold());
    }

    IEnumerator AddGold() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentGold += goldAdditionPerSecond;
            UpdateGoldText();
        }
    }

    public void UpdateGoldText()
    {
        goldText.text = "Gold: " + Mathf.RoundToInt(currentGold).ToString();
    }

    public float GetCurrentGold() { return currentGold; }

    public void BuyUnit(float cost) { if (cost <= currentGold) { currentGold -= cost; } }

    public void RefundUnitCost(float cost) { currentGold += cost * refundValue; }
}
