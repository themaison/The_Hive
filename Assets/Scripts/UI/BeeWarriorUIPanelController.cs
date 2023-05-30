using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeWarriorUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _damagePointsText;
    [SerializeField] private Text _detectionRangeText;

    public void UpdateBeeWarriorUIPanel(BeeWarriorUpgrader.BeeWarriorStats stats, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = stats.maxHealthPoints.ToString();
        _satietyPointsText.text = stats.maxSatietyPoints.ToString();
        _flightSpeedText.text = stats.flightSpeed.ToString();
        _damagePointsText.text = stats.damagePoints.ToString();
        _detectionRangeText.text = stats.detectionRange.ToString();
    }
}
