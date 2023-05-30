using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeeBuyingSystem : MonoBehaviour, IBuyable
{
    [SerializeField] protected BeeUIPanelController _beePanel;
    [SerializeField] protected BeeSpawner _beeSpawner;
    [SerializeField] protected int _price;
    [SerializeField] protected float inflationaryGrowth;

    private void Start()
    {
        _beePanel.UpdateBuyPriceUI(_price);
    }

    protected void UpdateBuyButton()
    {
        if (Hive.BeeOccupancy < Hive.BeeCapacity && Hive.HoneyOccupancy >= _price)
        {
            _beePanel.EnableBuyButton();
            _beePanel.SetMaxBuyUI("视先臆");
        }
        else
        {
            if (Hive.BeeOccupancy == Hive.BeeCapacity)
            {
                _beePanel.SetMaxBuyUI("汤恃.");
            }
            else
            {
                _beePanel.SetMaxBuyUI("视先臆");
            }
            _beePanel.DisableBuyButton();
        }
    }

    public virtual void Buy()
    {
        Hive.HoneyOccupancy -= _price;
        UpdatePrice();
        _beePanel.UpdateBuyPriceUI(_price);
    }
    protected virtual void UpdatePrice()
    {
        _price = (int)(_price * inflationaryGrowth);
    }
}
