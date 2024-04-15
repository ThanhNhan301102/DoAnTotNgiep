using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI valueText;

    public void UpdateFillBar(int currentVal, int maxVal)
    {
        fillBar.fillAmount = (float)currentVal / (float)maxVal;
        valueText.text = currentVal.ToString() + " / " + maxVal.ToString();
    }
}
