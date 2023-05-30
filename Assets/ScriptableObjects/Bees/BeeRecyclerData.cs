using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeeRecyclerData", menuName = "Bee/Bee Recycler")]
public class BeeRecyclerData : ScriptableObject
{
    public string name;
    public int healthPoints;
    public int satietyPoints;
    public float flightSpeed;
    public float NPR;
    public int productionEfficiency;
}
