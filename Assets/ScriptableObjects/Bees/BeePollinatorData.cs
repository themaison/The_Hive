using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeePollinatorData", menuName = "Bee/Bee Pollinator")]
public class BeePollinatorData : ScriptableObject
{   
    public string name;
    public int healthPoints;
    public int satietyPoints;
    public float flightSpeed;
    public float NCR;
    public int nectarCapacity;
}
    


