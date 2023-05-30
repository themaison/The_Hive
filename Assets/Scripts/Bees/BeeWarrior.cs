using UnityEngine;

public class BeeWarrior : Bee
{
    public static int beeWarriorAmount;

    [SerializeField] private BeeWarriorData _beeWarriorData;

    new private static int _maxHealthPoints;
    new private static int _maxSatietyPoints;
    new private static float _flightSpeed;
    private static int _damagePoints;
    private static float _detectionRange;

    private const float _damageFrequency = 1;

    private Enemy _nearestEnemy;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _targetPosition;
    private float _damageTime = 0f;
    private bool _isNearHive;

    void Start()
    {
        SetBeeWarriorStats(_beeWarriorData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindAnyObjectByType<Hive>();

        _isNearHive = false;
        _currentHealthPoints = _maxHealthPoints;
        _currentSatietyPoints = _maxSatietyPoints;

        SetHintPanelSettings();
        UpdateHungerProcess(_hungerDelay);
        UpdateEatingProcess(_eatDelay);
    }

    void Update()
    {
        if (_nearestEnemy == null)
        {
            FindNearestEnemy();
        }

        Fly();
        Regenerate();
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
        if (collision.gameObject.tag == "hive")
        {
            _spriteRenderer.enabled = false;
            _isNearHive = true;
            _targetPosition = transform.position; 

            UpdateHungerProcess(_hungerDelay + _hungerDelayBoost);  // slower speed hunger process
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("hive"))
        {
            _spriteRenderer.enabled = true;
            _isNearHive = false;

             UpdateHungerProcess(_hungerDelay);  // faster speed hunger process
        }
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

    public void SetBeeWarriorStats(BeeWarriorData BWD)
    {
        _name = BWD.name;
        _maxHealthPoints = BWD.healthPoints;
        _maxSatietyPoints = BWD.satietyPoints;
        _flightSpeed = BWD.flightSpeed;
        _damagePoints = BWD.damagePoints;
        _detectionRange = BWD.detectionRange;
    }

    public static void UpdateBeeWarriorStats(BeeWarriorData data)
    {
        _maxHealthPoints = data.healthPoints;
        _maxSatietyPoints = data.satietyPoints;
        _flightSpeed = data.flightSpeed;
        _damagePoints = data.damagePoints;
        _detectionRange = data.detectionRange;
    }
}