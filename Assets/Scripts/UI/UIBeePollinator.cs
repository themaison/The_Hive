using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBeePollinator : MonoBehaviour
{
    [SerializeField] private int _maxLevel;

    [SerializeField] private Hive _hive;
    [SerializeField] private BeePollinatorData _beePollinatorData;

    [SerializeField] private Text _levelText;

    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _buyText;
    [SerializeField] private Text _upgradeText;

    [SerializeField] private Text _healthPointsText;
    [SerializeField] private Text _satietyPointsText;
    [SerializeField] private Text _flightSpeedText;
    [SerializeField] private Text _NCRText;
    [SerializeField] private Text _nectarCapacityText;

    private int _level;
    private string _maxAmountText = "Ã¿ —.  ŒÀ.";
    private string _maxLevelText = "Ã¿ —. ”–.";

    void Start()
    {
        _level = 1;
        SetUIData();
    }

    public void Buy()
    {
        //if (_hive.)
    }
    
    public void Upgrade()
    {
        if (_level < _maxLevel)
        {

        }
        else
        {

        }
    }

    private void SetUIData()
    {
        _levelText.text = "”–Œ¬≈Õ‹ " + _level.ToString();
        _healthPointsText.text = _beePollinatorData.healthPoints.ToString();
        _satietyPointsText.text = _beePollinatorData.satietyPoints.ToString();
        _flightSpeedText.text = _beePollinatorData.flightSpeed.ToString();
        _NCRText.text = _beePollinatorData.NCR.ToString();
        _nectarCapacityText.text = _beePollinatorData.nectarCapacity.ToString();
    }
}
