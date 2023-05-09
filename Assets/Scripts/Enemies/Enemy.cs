using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    [SerializeField]
    protected GameObject targetBeeObject;
    [SerializeField]
    protected int damagePoints; // ���-�� ���������� �����

    public virtual void Bite()
    {
        // ����������� �����!
    }
}
