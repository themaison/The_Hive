using UnityEngine;

public abstract class Bee : FlyingEntity
{
    protected int beeObjectsCount; // ���-�� �������� "Bee"
    protected int satietyPoints; // ���� �������
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
