using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    [SerializeField]
    protected int _damagePoints; // ���-�� ���������� �����\
    protected GameObject _target;

    public virtual void Bite(Bee bee)
    {
        bee.TakeDamage(_damagePoints);
    }

}
