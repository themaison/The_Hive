using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeePollinatorUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _NCRText;
    [SerializeField] private Text _nectarCapacityText;

    public void UpdateBeePollinatorUIPanel(BeePollinatorUpgrader.BeePollinatorStats stats, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = stats.maxHealthPoints.ToString();
        _satietyPointsText.text = stats.maxSatietyPoints.ToString();
        _flightSpeedText.text = stats.flightSpeed.ToString();
        _NCRText.text = stats.NCR.ToString();
        _nectarCapacityText.text = stats.nectarCapacity.ToString();
    }
}
