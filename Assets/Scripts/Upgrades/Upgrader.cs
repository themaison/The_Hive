using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrader : MonoBehaviour, IUpgradable
{
    protected int _maxLevel;
    protected int _level;

    public abstract void Upgrade();
}
