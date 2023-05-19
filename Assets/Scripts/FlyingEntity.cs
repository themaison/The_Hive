using UnityEngine;

public abstract class FlyingEntity : MonoBehaviour
{
    [SerializeField] protected int _healthPoints;
    [SerializeField] protected float _flightSpeed;

    protected abstract void Fly();
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        if (_healthPoints <= 0)
        {
            Die();
        }
    }
}
