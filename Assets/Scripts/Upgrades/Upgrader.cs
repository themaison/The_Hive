using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrader : MonoBehaviour, IUpgradable
{
    [SerializeField] protected int _maxLevel;
    [SerializeField] protected int _level;

    public int MaxLevel => _maxLevel;
    public int Level => _level;

    public abstract void Upgrade();
}
