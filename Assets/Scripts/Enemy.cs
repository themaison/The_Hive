using UnityEngine;

public abstract class Enemy : FlyingEntity
{
    [SerializeField]
    protected GameObject targetBeeObject;
    protected int damagePoints; // кол-во наносимого урона

    public virtual void Bite()
    {
        // РЕАЛИЗОВАТЬ СУЧКИ!
    }
}
