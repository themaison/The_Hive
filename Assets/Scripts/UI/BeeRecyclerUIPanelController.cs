using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeRecyclerUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _productionEfficiencyText;
    [SerializeField] private Text _NPRText;

    public void UpdateBeeRecyclerUIPanel(BeeRecyclerUpgrader.BeeRecyclerStats stats, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = stats.maxHealthPoints.ToString();
        _satietyPointsText.text = stats.maxSatietyPoints.ToString();
        _flightSpeedText.text = stats.flightSpeed.ToString();
        _productionEfficiencyText.text = stats.productionEfficiency.ToString();
        _NPRText.text = stats.NPR.ToString();
    }
}
