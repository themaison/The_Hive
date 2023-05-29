using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeePollinatorUIPanelController : BeeUIPanelController
{
    [SerializeField] private Text _NCRText;
    [SerializeField] private Text _nectarCapacityText;

    public void UpdateBeePollinatorUIPanel(BeePollinatorData data, int level, int price)
    {
        UpdateLevelUI(level);
        UpdateUpgradePriceUI(price);

        _healthPointsText.text = data.healthPoints.ToString();
        _satietyPointsText.text = data.satietyPoints.ToString();
        _flightSpeedText.text = data.flightSpeed.ToString();
        _NCRText.text = data.NCR.ToString();
        _nectarCapacityText.text = data.nectarCapacity.ToString();
    }
}
