using UnityEngine;

public abstract class Bee : FlyingEntity
{
    public static int beeCounter = 0; // ���-�� �������� "Bee"
    [SerializeField]
    protected int satietyPoints; // ���� �������
    [SerializeField]
    protected int HRR; // health regeneration rate (�������� �������������� ��������)

    public virtual void Eat() // ������ �� �������
    {
        // ����������� �����!
    }

    public virtual void Regenerate() // ����������������� �� �������
    {
        // ����������� �����!
    }
}
