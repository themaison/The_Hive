using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    [SerializeField]
    protected GameObject targetBeeObject;
    protected int damagePoints; // ���-�� ���������� �����

    public virtual void Bite()
    {
        // ����������� �����!
    }
}
