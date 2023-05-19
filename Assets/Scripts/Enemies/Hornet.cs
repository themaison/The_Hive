using UnityEngine;

public class Hornet : Enemy
{

    private void Start()
    {
        _target = FindObjectOfType<Hive>().gameObject;
    }

    private void Update()
    {
        Fly();
    }

    protected override void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flightSpeed * Time.deltaTime);
    }
}
