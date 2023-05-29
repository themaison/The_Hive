using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWarriorUpgrader : Upgrader
{
    [SerializeField] private BeeWarriorData _beeWarriorData;
    [SerializeField] private BeeWarriorUIPanelController _beeWarriorUIPanel;
    [Serializable]
    private class BeeWarriorStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public int flightSpeed;
        public int damagePoints;
        public int detectionRange;
    }

    [SerializeField] private BeeWarriorStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;

    private BeeWarriorStats _upgrade;

    private void Start()
    {
        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _beeWarriorUIPanel.UpdateBeeWarriorUIPanel(_beeWarriorData, _level, GetUpgradePrice(_level - 1));
    }

    private void Update()
    {
        if (_level < _maxLevel && Hive.honeyOccupancy >= GetUpgradePrice(_level - 1))
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
        Hive.honeyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _upgrade = _upgrades[_level - 2];

        _beeWarriorData.healthPoints = _upgrade.maxHealthPoints;
        _beeWarriorData.satietyPoints = _upgrade.maxSatietyPoints;
        _beeWarriorData.flightSpeed = _upgrade.flightSpeed;
        _beeWarriorData.damagePoints = _upgrade.damagePoints;
        _beeWarriorData.detectionRange = _upgrade.detectionRange;
        BeeWarrior.UpdateBeeWarriorStats(_beeWarriorData);

        _beeWarriorUIPanel.UpdateBeeWarriorUIPanel(_beeWarriorData, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

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
