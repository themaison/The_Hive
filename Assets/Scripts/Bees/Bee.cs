using UnityEngine;

public abstract class Bee : FlyingEntity
{
    protected static int _beeCounter = 0; // ���-�� �������� "Bee"
    public static int BeeCounter
    {
        get { return _beeCounter; }
        set { _beeCounter = value; }
    }

    [SerializeField] protected int satietyPoints; // ���� �������
    [SerializeField] protected int HRR; // health regeneration rate (�������� �������������� ��������)

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



    public virtual void Eat() // ������ �� �������
    {
        // ����������� �����!
    }

    public virtual void Regenerate() // ����������������� �� �������
    {
        // ����������� �����!
    }
}
