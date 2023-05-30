using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static BeePollinatorUpgrader;

public class BeeRecyclerUpgrader : Upgrader
{
    [SerializeField] private BeeRecyclerData _data;
    [SerializeField] private BeeRecyclerUIPanelController _beeRecyclerUIPanel;

    [Serializable] public class BeeRecyclerStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public float flightSpeed;
        public int productionEfficiency;
        public float NPR;
    }

    [SerializeField] private BeeRecyclerStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;

    private BeeRecyclerStats _currentStats;

    private void Start()
    {
        _currentStats = new BeeRecyclerStats();
        _currentStats.maxHealthPoints = _data.healthPoints;
        _currentStats.maxSatietyPoints = _data.satietyPoints;
        _currentStats.flightSpeed = _data.flightSpeed;
        _currentStats.productionEfficiency = _data.productionEfficiency;
        _currentStats.NPR = _data.NPR;

        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _beeRecyclerUIPanel.UpdateBeeRecyclerUIPanel(_currentStats, _level, GetUpgradePrice(_level - 1));
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
        _currentStats = _upgrades[_level - 2];

        BeeRecycler.MaxHealthPoints = _currentStats.maxHealthPoints;
        BeeRecycler.MaxSatietyPoints = _currentStats.maxSatietyPoints;
        BeeRecycler.FlightSpeed = _currentStats.flightSpeed;
        BeeRecycler.ProductionEfficiency = _currentStats.productionEfficiency;
        BeeRecycler.NPR = _currentStats.NPR;

        _beeRecyclerUIPanel.UpdateBeeRecyclerUIPanel(_currentStats, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

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
