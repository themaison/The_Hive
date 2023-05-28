using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeePollinatorUIPanellController : BeeUIPanelController
{
    [SerializeField] private Text _NCRText;
    [SerializeField] private Text _nectarCapacityText;

    [SerializeField] private BeePollinatorUpgrader _upgrader;

    private void Start()
    {
        UpdateUIPanel();
    }

    public override void UpdateUIPanel()
    {
        _levelText.text = "спнбемэ " + _upgrader.Level.ToString();
        //_healthPointsText.text = _beePollinatorData.healthPoints.ToString();
        //_satietyPointsText.text = _beePollinatorData.satietyPoints.ToString();
        //_flightSpeedText.text = _beePollinatorData.flightSpeed.ToString();
        //_NCRText.text = _beePollinatorData.NCR.ToString();
        //_nectarCapacityText.text = _beePollinatorData.nectarCapacity.ToString();
    }
}
