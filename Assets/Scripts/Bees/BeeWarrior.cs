using UnityEngine;

public class BeeWarrior : Bee
{
    public static int beeWarriorAmount;

    [SerializeField] private BeeWarriorData _beeWarriorData;

    new private static int _maxHealthPoints = 0;
    new private static int _maxSatietyPoints = 0;
    new private static float _flightSpeed = 0;
    private static int _damagePoints = 0;
    private static float _detectionRange = 0;

    public static int MaxHealthPoints
    {
        get { return _maxHealthPoints; }
        set { _maxHealthPoints = value; }
    }
    public static int MaxSatietyPoints
    {
        get { return _maxSatietyPoints; }
        set { _maxSatietyPoints = value; }
    }
    public static float FlightSpeed
    {
        get { return _flightSpeed; }
        set { _flightSpeed = value; }
    }

    public static int DamagePoints
    {
        get { return _damagePoints; }
        set { _damagePoints = value; }
    }

    public static float DetectionRange
    {
        get { return _detectionRange; }
        set { _detectionRange = value; }
    }

    private const float _damageFrequency = 1;

    private Enemy _nearestEnemy;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _targetPosition;
    private float _damageTime = _damageFrequency;
    private bool _isNearHive;

    void Start()
    {
        LoadData(_beeWarriorData);

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

    private void SpriteRender()
    {
        _spriteRenderer.flipX = transform.position.x < _targetPosition.x;
    }

    public void LoadData(BeeWarriorData data)
    {
        _name = data.name;

        _maxHealthPoints = Mathf.Max(_maxHealthPoints, data.healthPoints);
        base._maxHealthPoints = _maxHealthPoints;

        _maxSatietyPoints = Mathf.Max(_maxSatietyPoints, data.satietyPoints);
        base._maxSatietyPoints = _maxSatietyPoints;

        _flightSpeed = Mathf.Max(_flightSpeed, data.flightSpeed);
        base._flightSpeed = _flightSpeed;

        _damagePoints = Mathf.Max(_damagePoints, data.damagePoints);
        _detectionRange = Mathf.Max(_detectionRange, data.detectionRange);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("hive"))
        {
            //_spriteRenderer.enabled = true;
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

        if (collision.CompareTag("hive"))
        {
            //_spriteRenderer.enabled = false;
            _isNearHive = true;
            _targetPosition = transform.position;

            UpdateHungerProcess(_hungerDelay + _hungerDelayBoost);  // slower speed hunger process
        }
    }
}