using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void ResetAllData()
    {
        Bee.beeAmount = 0;

        BeePollinator.beePollinatorAmount = 0;
        BeePollinator.MaxHealthPoints = 0;
        BeePollinator.MaxSatietyPoints = 0;
        BeePollinator.FlightSpeed = 0;
        BeePollinator.NectarCapacity = 0;
        BeePollinator.NCR = 0;

        BeeRecycler.beeRecyclerAmount = 0;
        BeeRecycler.MaxHealthPoints = 0;
        BeeRecycler.MaxSatietyPoints = 0;
        BeeRecycler.FlightSpeed = 0;
        BeeRecycler.NPR = 0;
        BeeRecycler.ProductionEfficiency = 0;

        BeeWarrior.beeWarriorAmount = 0;
        BeeWarrior.MaxHealthPoints = 0;
        BeeWarrior.MaxSatietyPoints= 0;
        BeeWarrior.FlightSpeed = 0;
        BeeWarrior.DamagePoints = 0;
        BeeWarrior.DetectionRange = 0;

        Hive.BeeCapacity = 0;
        Hive.HoneyCapacity = 0;
        Hive.NectarCapacity = 0;
        Hive.MaxIntegrityPoints = 0;

        Wasp.MaxHealthPoints = 0;
        Wasp.FlightSpeed = 0;
        Wasp.damagePoints = 0;
        Wasp.damageFrequency = 0;

        Hornet.MaxHealthPoints = 0;
        Hornet.FlightSpeed = 0;
        Hornet.damagePoints = 0;
        Hornet.damageFrequency = 0;
    }
}
