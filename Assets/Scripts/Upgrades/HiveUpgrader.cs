using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BeeRecyclerUpgrader;

public class HiveUpgrader : Upgrader
{
    [SerializeField] private HiveData _data;
    [SerializeField] private HiveUIPanelController _hiveUIPanel;

    [Serializable]
    public class HiveStats
    {
        public int maxIntegrityPoints;
        public int beeCapacity;
        public int nectarCapacity;
        public int honeyCapacity;
    }

    [SerializeField] private HiveStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;

    private HiveStats _currentStats;

    void Start()
    {
        _currentStats = new HiveStats();
        _currentStats.maxIntegrityPoints = _data.maxIntegrityPoints;
        _currentStats.beeCapacity = _data.beeCapacity;
        _currentStats.nectarCapacity = _data.nectarCapacity;
        _currentStats.honeyCapacity = _data.honeyCapacity;

        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _hiveUIPanel.UpdateHiveUIPanel(_currentStats, _level, GetUpgradePrice(_level - 1));

    }

    private void Update()
    {
        if (_level < _maxLevel && Hive.HoneyOccupancy >= GetUpgradePrice(_level - 1))
        {
            _hiveUIPanel.EnableUpgradeButton();
        }
        else
        {
            _hiveUIPanel.DisableUpgradeButton();
        }
    }

    public override void Upgrade()
    {
        Hive.HoneyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _currentStats = _upgrades[_level - 2];

        Hive.MaxIntegrityPoints = _currentStats.maxIntegrityPoints;
        Hive.BeeCapacity = _currentStats.beeCapacity;
        Hive.HoneyCapacity = _currentStats.honeyCapacity;
        Hive.NectarCapacity = _currentStats.nectarCapacity;
        Hive.CurrentIntegrityPoints = Hive.MaxIntegrityPoints;

        _hiveUIPanel.UpdateHiveUIPanel(_currentStats, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

        if (_level == _maxLevel)
        {
            _hiveUIPanel.DisableUpgradeButton();
            _hiveUIPanel.SetMaxUpgradeUI();
        }
    }

    private int GetUpgradePrice(int level)
    {
        return _upgradePrices[level];
    }
}
