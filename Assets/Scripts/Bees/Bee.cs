using UnityEngine;

public abstract class Bee : FlyingEntity
{
    protected int beeObjectsCount; // кол-во объектов "Bee"
    protected int satietyPoints; // очки сытости
    protected int HRR; // health regeneration rate (скорость восстановлени€ здоровь€)


    public virtual void Eat() // кушают по формуле
    {
        // –≈јЋ»«ќ¬ј“№ —”„ »!
    }

    public virtual void Regenerate() // восстанавливаютс€ по формуле
    {
        // –≈јЋ»«ќ¬ј“№ —”„ »!
    }
}
