using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspUpgrader : Upgrader
{
    [SerializeField] private EnemyData _data;

    [SerializeField] private float _gainHealthPoints;
    [SerializeField] private float _gainDamagePoints;
    [SerializeField] private float _gainFlightSpeed;

    private void Start()
    {
        _level = 1;
        _maxLevel = _level;
    }

    public override void Upgrade()
    {
        _level += 1;
        _maxLevel = _level;

        Wasp.MaxHealthPoints = (int)Mathf.Ceil(Wasp.MaxHealthPoints * _gainHealthPoints);
        Wasp.FlightSpeed *= _gainFlightSpeed;
        Wasp.damagePoints = (int)Mathf.Ceil(Wasp.damagePoints * _gainDamagePoints);
    }
}
