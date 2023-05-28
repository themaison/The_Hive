using Unity.VisualScripting;
using UnityEngine;

public class Wasp : Enemy
{
    [SerializeField] protected EnemyData _enemyData;

    private SpriteRenderer _spriteRenderer;
    private Hive _hive;

    private float _damageTime = 0f;

    private void Start()
    {
        SetEnemyData(_enemyData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();
        _damageTime = _damageFrequency;

        _currentHealthPoints = _maxHealthPoints;

        SetHintPanelSettings();
    }

    private void Update()
    {
        FindNearestTarget();
        Fly();
        _spriteRenderer.flipX = _target.transform.position.x >= transform.position.x;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hive"))
        {
            Die();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bee")
        {
            _damageTime += Time.deltaTime;
            if (_damageTime >= _damageFrequency)
            {
                Bee bee = collision.gameObject.GetComponent<Bee>();
                Bite(bee);
                _damageTime = 0f;
            }
        }
    }
}
