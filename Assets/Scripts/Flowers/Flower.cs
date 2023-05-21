using Unity.VisualScripting;
using UnityEngine;

public abstract class Flower : StaticObject
{
    protected static int _flowersCount = 0;
    protected int _maxPollenCount;
    protected int _pollenCount;

    public static int FlowersCount
    {
        get { return _flowersCount; }
        set { _flowersCount = value; }
    }

    public int PollenCount
    {
        get { return _pollenCount; }
        set { _pollenCount = value; }
    }

    protected void InitPollenCount()
    {
        _pollenCount = Random.Range(1, _maxPollenCount + 1);
    }
}
