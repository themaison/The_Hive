using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string name;
    public int healthPoints;
    public float flightSpeed;
    public int damagePoints;
    public float damageFrequency;
}
