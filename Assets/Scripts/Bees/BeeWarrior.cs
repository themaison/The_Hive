using UnityEngine;

public class BeeWarrior : Bee
{
    private static int _beeWarriorCounter;
    public static int BeeWarriorCounter
    {
        get { return _beeWarriorCounter; }
        set { _beeWarriorCounter = value; }
    }

    [SerializeField] private int _damagePoints;
    [Range(0.1f, 5.0f)]
    [SerializeField] private float _damageFrequency;
    [SerializeField] private float _detectionRange;

    private Enemy _nearestEnemy;
    private Hive _hive;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _targetPosition;
    private float _damageTime = 0f;
    private bool _isNearHive;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindAnyObjectByType<Hive>();
        _isNearHive = false;
    }

    void Update()
    {
        if (_nearestEnemy == null)
        {
            FindNearestEnemy();
        }

        Fly();
        SpriteRender();
    }

    private void FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>(); 

        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= _detectionRange)
            {
                closestDistance = distance;
                _nearestEnemy = enemy;
            }
        }
    }

    protected override void Fly()
    {
        if (_nearestEnemy != null)
        {
            _targetPosition = _nearestEnemy.transform.position;
        }
        else if (!_isNearHive)
        {
            _targetPosition = _hive.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _flightSpeed * Time.deltaTime);
    }

    private void Bite(Enemy enemy)
    {
        enemy.TakeDamage(_damagePoints);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetPosition = transform.position;
        _isNearHive = true;
        //if (collision.gameObject.tag == "hive")
        //{
        //    _spriteRenderer.enabled = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isNearHive = false;
        //if (collision.gameObject.tag == "hive")
        //{
        //    _spriteRenderer.enabled = true;
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            _damageTime += Time.deltaTime;
            if (_damageTime >= _damageFrequency)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                Bite(enemy);
                _damageTime = 0f;
            }
        }
    }

    private void SpriteRender()
    {
        _spriteRenderer.flipX = transform.position.x < _targetPosition.x;
    }
}