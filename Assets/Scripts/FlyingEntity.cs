using UnityEngine;

public abstract class FlyingEntity : MonoBehaviour
{
    protected int healthPoints; // очки здоровья
    protected int flightSpeed; // скорость полета

    public abstract void Fly(); // лететь (летают по разному)
}
