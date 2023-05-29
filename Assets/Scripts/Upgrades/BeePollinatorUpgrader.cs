using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeePollinatorUpgrader : Upgrader
{
    [SerializeField] private BeePollinatorData _beePollinatorData;
    [SerializeField] private BeePollinatorUIPanelController _beePollinatorUIPanel;
    [Serializable] private class BeePollinatorStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public int flightSpeed;
        public int NCR;
        public int nectarCapacity;
    }

    [SerializeField] private BeePollinatorStats[] _upgrades;
    [SerializeField] private int[] _upgradePrices;
    
    private BeePollinatorStats _upgrade;

    private void Start()
    {
        _maxLevel = _upgrades.Length + 1;
        _level = 1;

        _beePollinatorUIPanel.UpdateBeePollinatorUIPanel(_beePollinatorData, _level, GetUpgradePrice(_level - 1));
    }

    private void Update()
    {
        if (_level < _maxLevel &&  Hive.honeyOccupancy >= GetUpgradePrice(_level - 1))
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
        Hive.honeyOccupancy -= GetUpgradePrice(_level - 1);

        _level += 1;
        _upgrade = _upgrades[_level - 2];

        _beePollinatorData.healthPoints = _upgrade.maxHealthPoints;
        _beePollinatorData.satietyPoints = _upgrade.maxSatietyPoints;
        _beePollinatorData.flightSpeed = _upgrade.flightSpeed;
        _beePollinatorData.NCR = _upgrade.NCR;
        _beePollinatorData.nectarCapacity = _upgrade.nectarCapacity;
        BeePollinator.UpdateBeePollinatorStats(_beePollinatorData);

        _beePollinatorUIPanel.UpdateBeePollinatorUIPanel(_beePollinatorData, _level, GetUpgradePrice(Math.Min(_level - 1, _maxLevel - 2)));

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
