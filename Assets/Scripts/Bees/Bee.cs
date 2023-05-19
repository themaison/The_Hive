using UnityEngine;

public abstract class Bee : FlyingEntity
{
    protected static int _beeCounter = 0; // кол-во объектов "Bee"
    public static int BeeCounter
    {
        get { return _beeCounter; }
        set { _beeCounter = value; }
    }

    [SerializeField] protected int satietyPoints;
    [SerializeField] protected int HRR; // health regeneration rate

    protected virtual void Eat()
    {
       // soon
    }

    protected virtual void Regenerate()
    {
        // soon
    }
}
