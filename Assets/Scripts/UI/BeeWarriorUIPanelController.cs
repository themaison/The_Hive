using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeWarriorUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _damagePointsText;
    [SerializeField] private Text _detectionRangeText;

    public void UpdateBeeWarriorUIPanel(BeeWarriorData data, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = data.healthPoints.ToString();
        _satietyPointsText.text = data.satietyPoints.ToString();
        _flightSpeedText.text = data.flightSpeed.ToString();
        _damagePointsText.text = data.damagePoints.ToString();
        _detectionRangeText.text = data.detectionRange.ToString();
    }
}
