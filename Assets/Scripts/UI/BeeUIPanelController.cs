using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BeeUIPanelController : MonoBehaviour
{
    [SerializeField] protected Text _levelText;

    [SerializeField] protected Button _buyButton;
    [SerializeField] protected Button _upgradeButton;
    [SerializeField] protected Text _buyText;
    [SerializeField] protected Text _upgradeText;

    [SerializeField] protected Text _healthPointsText;
    [SerializeField] protected Text _satietyPointsText;
    [SerializeField] protected Text _flightSpeedText;

    public abstract void UpdateUIPanel();
}
