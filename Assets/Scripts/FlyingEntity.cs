using UnityEngine;

public abstract class FlyingEntity : MonoBehaviour
{
    [SerializeField] protected int _healthPoints;
    [SerializeField] protected float _flightSpeed;

    protected abstract void Fly();
}
