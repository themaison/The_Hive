using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveUIPanelController : MonoBehaviour
{
    [SerializeField] private Color _indicatorMaxValue;

    [SerializeField] private Text _levelText;

    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _upgradeButtonText;
    [SerializeField] private Text _upgradePriceText;

    [SerializeField] private Text _maxIntegrityPointsText;
    [SerializeField] private Text _beeCapacityText;
    [SerializeField] private Text _nectarCapacityText;
    [SerializeField] private Text _honeyCapacityText;

    public virtual void DisableUpgradeButton()
    {
        _upgradeButton.interactable = false;
    }

    public virtual void EnableUpgradeButton()
    {
        _upgradeButton.interactable = true;
    }

    public void SetMaxUpgradeUI()
    {
        _upgradeButtonText.text = "����. ��.";
        _upgradeButtonText.color = _indicatorMaxValue;
        _upgradePriceText.text = "-/-";
    }

    public void UpdateHiveUIPanel(HiveUpgrader.HiveStats stats, int level, int price)
    {
        _levelText.text = "������� " + level.ToString();
        _upgradePriceText.text = price.ToString();

        _maxIntegrityPointsText.text = stats.maxIntegrityPoints.ToString();
        _beeCapacityText.text = stats.beeCapacity.ToString();
        _nectarCapacityText.text = stats.nectarCapacity.ToString();
        _honeyCapacityText.text = stats.honeyCapacity.ToString();
    }
}
