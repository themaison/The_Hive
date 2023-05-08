using UnityEngine;

public class BeeWarrior : Bee
{
    private Rigidbody2D rb;
    private int _beeWarriorObjectsCount;
    private int _damagePoints; // ���-�� ���������� �����

    public void Bite() // ������
    {
        // ����������� �����!
    }

    public override void Fly()
    {
        rb.velocity = Vector2.up;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fly();
    }
}
