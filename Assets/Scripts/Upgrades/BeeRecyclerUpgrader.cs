using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeeRecyclerUpgrader : Upgrader
{
    [SerializeField] private BeeRecyclerData _beeRecyclerData;
    [SerializeField] private BeeRecyclerUIPanelController _beeRecyclerUIPanel;

    [Serializable]
    private class BeeRecyclerStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public int flightSpeed;
        public int productionEfficiency;
        public int NPR;
    }

    [SerializeField] private BeeRecyclerStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;

    private BeeRecyclerStats _upgrade;

    private void Start()
    {
        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _beeRecyclerUIPanel.UpdateBeeRecyclerUIPanel(_beeRecyclerData, _level, GetUpgradePrice(_level - 1));
    }

    private void Update()
    {
        if (_level < _maxLevel && Hive.HoneyOccupancy >= GetUpgradePrice(_level - 1))
        {
            _beeRecyclerUIPanel.EnableUpgradeButton();
        }
        else
        {
            _beeRecyclerUIPanel.DisableUpgradeButton();
        }
    }

    public override void Upgrade()
    {
        Hive.HoneyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _upgrade = _upgrades[_level - 2];

        _beeRecyclerData.healthPoints = _upgrade.maxHealthPoints;
        _beeRecyclerData.satietyPoints = _upgrade.maxSatietyPoints;
        _beeRecyclerData.flightSpeed = _upgrade.flightSpeed;
        _beeRecyclerData.productionEfficiency = _upgrade.productionEfficiency;
        _beeRecyclerData.NPR = _upgrade.NPR;
        BeeRecycler.UpdateBeeRecyclerStats(_beeRecyclerData);

        _beeRecyclerUIPanel.UpdateBeeRecyclerUIPanel(_beeRecyclerData, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

        if (_level == _maxLevel)
        {
            _beeRecyclerUIPanel.DisableUpgradeButton();
            _beeRecyclerUIPanel.SetMaxUpgradeUI();
        }
    }

    private int GetUpgradePrice(int level)
    {
        return _upgradePrices[level];
    }
}
