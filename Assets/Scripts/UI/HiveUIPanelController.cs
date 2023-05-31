using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiveUIPanelController : MonoBehaviour
{
    [SerializeField] private Color _maxValueColor;
    [SerializeField] private Color _defaultTextColor;

    [SerializeField] private Text _levelText;

    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _upgradeButtonText;
    [SerializeField] private Text _upgradePriceText;

    [SerializeField] private Text _maxIntegrityPointsText;
    [SerializeField] private Text _beeCapacityText;
    [SerializeField] private Text _nectarCapacityText;
    [SerializeField] private Text _honeyCapacityText;

    [SerializeField] private Button _restoreButton;
    [SerializeField] private Text _restoreButtonText;
    [SerializeField] private Text _restorePriceText;

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
        _upgradeButtonText.text = "Ã¿ —.";
        _upgradeButtonText.color = _maxValueColor;
        _upgradePriceText.text = "-/-";
    }

    public void UpdateHiveUIPanel(HiveUpgrader.HiveStats stats, int level, int price)
    {
        _levelText.text = "”–Œ¬≈Õ‹ " + level.ToString();
        _upgradePriceText.text = price.ToString();

        _maxIntegrityPointsText.text = stats.maxIntegrityPoints.ToString();
        _beeCapacityText.text = stats.beeCapacity.ToString();
        _nectarCapacityText.text = stats.nectarCapacity.ToString();
        _honeyCapacityText.text = stats.honeyCapacity.ToString();
    }

    public void SetVoidRestore()
    {
        _restoreButton.interactable = false;
        _restoreButtonText.text = "Ã¿ —.";
        _restoreButtonText.color = _maxValueColor;
    }

    public void EnableRestoreButton()
    {
        _restoreButton.interactable = true;
        _restoreButtonText.color = _defaultTextColor;
        _restoreButtonText.text = "œŒ◊»Õ»“‹";
    }

    public void DisableRestoreButton()
    {
        _restoreButton.interactable = false;
        _restoreButtonText.color = _defaultTextColor;
        _restoreButtonText.text = "œŒ◊»Õ»“‹";
    }

    public void UpdatePriceText(int price)
    {
        _restorePriceText.text = price.ToString();
    }
}
