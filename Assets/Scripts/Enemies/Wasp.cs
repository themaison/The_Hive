using Unity.VisualScripting;
using UnityEngine;

public class Wasp : Enemy
{
    private SpriteRenderer _sr;
    private Hive _hive;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();
    }

    private void Update()
    {
        FindNearestTarget();
        Fly();
        _sr.flipX = _target.transform.position.x >= transform.position.x;
    }

    protected override void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flightSpeed * Time.deltaTime);
    }

    private void FindNearestTarget()
    {
        Bee[] bees = FindObjectsOfType<Bee>();

        float minDistance = Mathf.Infinity;

        foreach (Bee bee in bees)
        {
            float distance = Vector2.Distance(transform.position,bee.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _target = bee.gameObject;
            }
        }

        float _hiveDistance = Vector2.Distance(transform.position, _hive.transform.position);
        if (_hiveDistance < minDistance)
        {
            minDistance = _hiveDistance;
            _target = _hive.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive")
        {
            //collision.GetComponent<Hive>()
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "bee")
        {
            Destroy(collision.gameObject, 2);
        }
    }
}
