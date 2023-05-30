using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeeWarriorData", menuName = "Bee/Bee Warrior")]
public class BeeWarriorData : ScriptableObject
{
    public string name;
    public int healthPoints;
    public int satietyPoints;
    public float flightSpeed;
    public int damagePoints;
    public float detectionRange;
}
