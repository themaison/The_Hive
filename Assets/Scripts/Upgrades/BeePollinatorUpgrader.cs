using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeePollinatorUpgrader : Upgrader
{
    [SerializeField] private BeePollinatorData _beePollinatorData;
    public class BeePollinatorStats
    {
        public int maxHealthPoints;
        public int maxSatietyPoints;
        public int flightSpeed;
        public int NCR;
        public int nectarCapacity;
    }

    private BeePollinatorStats[] _upgrades = new BeePollinatorStats[]
        {
            new BeePollinatorStats { maxHealthPoints = 10, maxSatietyPoints = 10, flightSpeed = 1, NCR = 5, nectarCapacity = 2 },
            new BeePollinatorStats { maxHealthPoints = 15, maxSatietyPoints = 11, flightSpeed = 2, NCR = 4, nectarCapacity = 4 },
            new BeePollinatorStats { maxHealthPoints = 20, maxSatietyPoints = 12, flightSpeed = 3, NCR = 3, nectarCapacity = 6 },
            new BeePollinatorStats { maxHealthPoints = 25, maxSatietyPoints = 13, flightSpeed = 4, NCR = 2, nectarCapacity = 8 },
            new BeePollinatorStats { maxHealthPoints = 30, maxSatietyPoints = 14, flightSpeed = 5, NCR = 1, nectarCapacity = 10 },
        };

    private BeePollinatorStats _upgrade;

    private void Start()
    {
        _level = 0;
    }

    public override void Upgrade()
    {
        _level += 1;
        _upgrade = _upgrades[_maxLevel - 1];

        _beePollinatorData.healthPoints = _upgrade.maxHealthPoints;
        _beePollinatorData.satietyPoints = _upgrade.maxSatietyPoints;
        _beePollinatorData.flightSpeed = _upgrade.flightSpeed;
        _beePollinatorData.NCR = _upgrade.NCR;
        _beePollinatorData.nectarCapacity = _upgrade.nectarCapacity;

        BeePollinator.UpdateBeePollinatorStats(_beePollinatorData);
    }
}
