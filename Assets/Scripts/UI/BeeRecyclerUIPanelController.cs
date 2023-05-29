using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeRecyclerUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _productionEfficiencyText;
    [SerializeField] private Text _NPRText;

    public void UpdateBeeRecyclerUIPanel(BeeRecyclerData data, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = data.healthPoints.ToString();
        _satietyPointsText.text = data.satietyPoints.ToString();
        _flightSpeedText.text = data.flightSpeed.ToString();
        _productionEfficiencyText.text = data.productionEfficiency.ToString();
        _NPRText.text = data.NPR.ToString();
    }
}
