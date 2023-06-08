using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    protected int _damagePoints;
    protected float _damageFrequency;

    protected GameObject _target;
    protected Hive _hive;

    protected float _damageTime = 0f;

    protected void Bite()
    {
        //_takeDamageAnim.SetBool("TakeDamageWasp", true);

        if (Time.time - _damageTime > _damageFrequency)
        {
            _target.GetComponent<Bee>().TakeDamage(_damagePoints);
            _damageTime = Time.time;
        }

        //_takeDamageAnim.SetBool("TakeDamageWasp", false);
    }

    protected void Break()
    {
        if (Time.time - _damageTime > _damageFrequency)
        {
            _hive.TakeDamage(_damagePoints);
            _damageTime = Time.time;
        }
    }
}
