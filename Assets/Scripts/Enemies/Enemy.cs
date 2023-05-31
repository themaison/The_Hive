using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    protected int _damagePoints;
    protected float _damageFrequency;

    protected GameObject _target;

    protected virtual void Bite(Bee bee)
    {
        bee.TakeDamage(_damagePoints);
    }

    public virtual void SetEnemyData(EnemyData ED)  // для Шершня (временно)
    {
        _name = ED.name;
        _maxHealthPoints = ED.healthPoints;
        _flightSpeed = ED.flightSpeed;
        _damagePoints = ED.damagePoints;
        _damageFrequency = ED.damageFrequency;
    }

}
