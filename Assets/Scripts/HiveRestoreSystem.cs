using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveRestoreSystem : MonoBehaviour
{
    [SerializeField] private HiveUIPanelController _hiveUIPanel;

    [SerializeField] private int _price;
    [SerializeField] private float _inflationaryGrowth;

    void Start()
    {
        _hiveUIPanel.UpdatePriceText(_price);
    }

    void Update()
    {
        if (Hive.CurrentIntegrityPoints < Hive.MaxIntegrityPoints)
        {
            if (Hive.HoneyOccupancy >= _price)
            {
                _hiveUIPanel.EnableRestoreButton();
            }
            else
            {
                _hiveUIPanel.DisableRestoreButton();
            }
        }
        else
        {
            _hiveUIPanel.SetVoidRestore();
        }
    }

    public void Restore()
    {
        Hive.CurrentIntegrityPoints += 1;
        Hive.HoneyOccupancy -= _price;

        UpdatePrice();
        _hiveUIPanel.UpdatePriceText(_price);
    }

    private void UpdatePrice()
    {
        _price = (int)Mathf.Ceil(_price*_inflationaryGrowth);
    }
}
