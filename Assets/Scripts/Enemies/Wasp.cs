using Unity.VisualScripting;
using UnityEngine;

public class Wasp : Enemy
{
    private SpriteRenderer _sr;
    private Hive _hive;
    private bool _attacked = false;

    [SerializeField] private float _attackTime = 0f;
    [SerializeField] private float _attackDelay = 5f;

    private void Start()
    {
        _attackTime = _attackDelay;
        _sr = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();
    }

    private void Update()
    {
        if (_attacked==true) _attackTime += Time.deltaTime;
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
            float distance = Vector2.Distance(transform.position, bee.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _target = bee.gameObject;
            }
        }

        float hiveDistance = Vector2.Distance(transform.position, _hive.transform.position);
        if (hiveDistance < minDistance)
        {
            minDistance = hiveDistance;
            _target = _hive.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hive"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("bee"))
        {
            _attacked = true;
            Bee bee = collision.gameObject.GetComponent<Bee>();
            //_attackTime += Time.deltaTime;
            if (_attackTime >= _attackDelay)
            {
                Bite(bee);
                _attackTime = 0f;
                _attacked = false;
            }
        }
    }
}
