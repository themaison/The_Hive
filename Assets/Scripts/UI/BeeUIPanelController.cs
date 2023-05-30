using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BeeUIPanelController : MonoBehaviour
{
    [SerializeField] protected Color _indicatorMaxValue;

    [SerializeField] protected Text _levelText;

    [SerializeField] protected Button _upgradeButton;
    [SerializeField] protected Text _upgradeButtonText;
    [SerializeField] protected Text _upgradePriceText;

    [SerializeField] protected Button _buyButton;
    [SerializeField] protected Text _buyButtonText;
    [SerializeField] protected Text _buyPriceText;

    [SerializeField] protected Text _healthPointsText;
    [SerializeField] protected Text _satietyPointsText;
    [SerializeField] protected Text _flightSpeedText;

    public virtual void DisableUpgradeButton()
    {
        _upgradeButton.interactable = false;
    }

    public virtual void EnableUpgradeButton()
    {
        _upgradeButton.interactable = true;
    }

    public virtual void DisableBuyButton()
    {
        _buyButton.interactable = false;
    }

    public virtual void EnableBuyButton()
    {
        _buyButton.interactable = true;
    }

    public void SetMaxUpgradeUI()
    {
        _upgradeButtonText.text = "Ã¿ —.";
        _upgradeButtonText.color = _indicatorMaxValue;
        _upgradePriceText.text = "-/-";
    }

    public void SetMaxBuyUI(string text)
    {
        _buyButtonText.text = text;
    }

    public virtual void UpdateUpgradePriceUI(int price)
    {
        _upgradePriceText.text = price.ToString();
    }

    public virtual void UpdateBuyPriceUI(int price)
    {
        _buyPriceText.text = price.ToString();
    }

    public virtual void UpdateLevelUI(int level)
    {
        _levelText.text = "”–Œ¬≈Õ‹ " + level.ToString();
    }
}
