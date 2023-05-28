using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FlowerData", menuName = "Static/Flower")]
public class FlowerData : ScriptableObject
{
    public string name;
    public int pollenAmount;
}
