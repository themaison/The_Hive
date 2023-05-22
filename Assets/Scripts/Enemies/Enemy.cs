using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    [Range(1, 100)]
    [SerializeField] protected int _damagePoints;
    [Range(0.1f, 5.0f)]
    [SerializeField] protected float _damageFrequency;

    protected GameObject _target;

    protected virtual void Bite(Bee bee)
    {
        bee.TakeDamage(_damagePoints);
    }

}
