using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HiveData", menuName = "Static/Hive")]
public class HiveData : ScriptableObject
{
    public string name;
    public int maxIntegrityPoints;
    public int beeCapacity;
    public int nectarCapacity;
    public int honeyCapacity;
}
