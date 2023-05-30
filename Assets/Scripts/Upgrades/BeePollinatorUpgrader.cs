using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeePollinatorUpgrader : Upgrader
{
    [SerializeField] private BeePollinatorData _data;
    [SerializeField] private BeePollinatorUIPanelController _beePollinatorUIPanel;
    [Serializable] public class BeePollinatorStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public float flightSpeed;
        public float NCR;
        public int nectarCapacity;
    }

    [SerializeField] private BeePollinatorStats[] _upgradeStats;
    [SerializeField] private int[] _upgradePrices;

    private BeePollinatorStats _currentStats;

    private void Start()
    {
        _currentStats = new BeePollinatorStats();
        _currentStats.maxHealthPoints = _data.healthPoints;
        _currentStats.maxSatietyPoints = _data.satietyPoints;
        _currentStats.flightSpeed = _data.flightSpeed;
        _currentStats.NCR = _data.NCR;
        _currentStats.nectarCapacity = _data.nectarCapacity;

        _maxLevel = _upgradeStats.Length + 1;
        _level = 1;

        _beePollinatorUIPanel.UpdateBeePollinatorUIPanel(_currentStats, _level, GetUpgradePrice(_level - 1));
    }

    private void Update()
    {
        if (_level < _maxLevel &&  Hive.HoneyOccupancy >= GetUpgradePrice(_level - 1))
        {
            _beePollinatorUIPanel.EnableUpgradeButton();
        }
        else
        {
            _beePollinatorUIPanel.DisableUpgradeButton();
        }
    }

    public override void Upgrade()
    {
        Hive.HoneyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _currentStats = _upgradeStats[_level - 2];

        BeePollinator.MaxHealthPoints = _currentStats.maxHealthPoints;
        BeePollinator.MaxSatietyPoints = _currentStats.maxSatietyPoints;
        BeePollinator.FlightSpeed = _currentStats.flightSpeed;
        BeePollinator.NCR = _currentStats.NCR;
        BeePollinator.NectarCapacity = _currentStats.nectarCapacity;

        _beePollinatorUIPanel.UpdateBeePollinatorUIPanel(_currentStats, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

        if (_level == _maxLevel)
        {
            _beePollinatorUIPanel.DisableUpgradeButton();
            _beePollinatorUIPanel.SetMaxUpgradeUI();
        }
    }

    private int GetUpgradePrice(int level)
    {
        return _upgradePrices[level];
    }
}
