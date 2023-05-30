using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BeeRecyclerUpgrader;

public class BeeWarriorUpgrader : Upgrader
{
    [SerializeField] private BeeWarriorData _data;
    [SerializeField] private BeeWarriorUIPanelController _beeWarriorUIPanel;
    [Serializable] public class BeeWarriorStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public float flightSpeed;
        public int damagePoints;
        public float detectionRange;
    }

    [SerializeField] private BeeWarriorStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;

    private BeeWarriorStats _currentStats;

    private void Start()
    {
        _currentStats = new BeeWarriorStats();
        _currentStats.maxHealthPoints = _data.healthPoints;
        _currentStats.maxSatietyPoints = _data.satietyPoints;
        _currentStats.flightSpeed = _data.flightSpeed;
        _currentStats.damagePoints = _data.damagePoints;
        _currentStats.detectionRange = _data.detectionRange;

        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _beeWarriorUIPanel.UpdateBeeWarriorUIPanel(_currentStats, _level, GetUpgradePrice(_level - 1));
    }

    private void Update()
    {
        if (_level < _maxLevel && Hive.HoneyOccupancy >= GetUpgradePrice(_level - 1))
        {
            _beeWarriorUIPanel.EnableUpgradeButton();
        }
        else
        {
            _beeWarriorUIPanel.DisableUpgradeButton();
        }
    }

    public override void Upgrade()
    {
        Hive.HoneyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _currentStats = _upgrades[_level - 2];

        BeeWarrior.MaxHealthPoints = _currentStats.maxHealthPoints;
        BeeWarrior.MaxSatietyPoints = _currentStats.maxSatietyPoints;
        BeeWarrior.FlightSpeed = _currentStats.flightSpeed;
        BeeWarrior.DamagePoints = _currentStats.damagePoints;
        BeeWarrior.DetectionRange = _currentStats.detectionRange;

        _beeWarriorUIPanel.UpdateBeeWarriorUIPanel(_currentStats, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

        if (_level == _maxLevel)
        {
            _beeWarriorUIPanel.DisableUpgradeButton();
            _beeWarriorUIPanel.SetMaxUpgradeUI();
        }
    }

    private int GetUpgradePrice(int level)
    {
        return _upgradePrices[level];
    }
}
