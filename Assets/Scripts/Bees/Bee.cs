using UnityEngine;

public abstract class Bee : FlyingEntity
{
    protected static int _beeCounter = 0; // кол-во объектов "Bee"
    public static int BeeCounter
    {
        get { return _beeCounter; }
        set { _beeCounter = value; }
    }

    [SerializeField] protected int satietyPoints; // очки сытости
    [SerializeField] protected int HRR; // health regeneration rate (скорость восстановлени€ здоровь€)

    public virtual void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        Debug.Log(_healthPoints);
        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }



    public virtual void Eat() // кушают по формуле
    {
        // –≈јЋ»«ќ¬ј“№ —”„ »!
    }

    public virtual void Regenerate() // восстанавливаютс€ по формуле
    {
        // –≈јЋ»«ќ¬ј“№ —”„ »!
    }
}
