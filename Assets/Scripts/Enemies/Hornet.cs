using Unity.VisualScripting;
using UnityEngine;

public class Hornet : Enemy
{
    [SerializeField] protected EnemyData _enemyData;

    private float hiveDistance = 0f;

    new private static int _maxHealthPoints;
    new private static float _flightSpeed;
    new private static int _damagePoints;
    new private static float _damageFrequency;

    public static int MaxHealthPoints
    {
        get { return _maxHealthPoints; }
        set { _maxHealthPoints = value; }
    }

    public static float FlightSpeed
    {
        get { return _flightSpeed; }
        set { _flightSpeed = value; }
    }

    public static int damagePoints
    {
        get { return _damagePoints; }
        set { _damagePoints = value; }
    }

    public static float damageFrequency
    {
        get { return _damageFrequency; }
        set { _damageFrequency = value; }
    }

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        LoadData(_enemyData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _currentHealthPoints = _maxHealthPoints;

        SetHintPanelSettings();
    }

    private void Update()
    {
        hiveDistance = Vector2.Distance(transform.position, _hive.transform.position);

        if (hiveDistance > 0.1)
        {
            Fly();
        }
        else
        {
            Break();
        }
    }

    protected override void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, _hive.transform.position, _flightSpeed * Time.deltaTime);
        _spriteRenderer.flipX = _hive.transform.position.x >= transform.position.x;
    }

    private void LoadData(EnemyData data)
    {
        _name = data.name;

        _maxHealthPoints = Mathf.Max(_maxHealthPoints, data.healthPoints);
        base._maxHealthPoints = _maxHealthPoints;

        _flightSpeed = Mathf.Max(_flightSpeed, data.flightSpeed);
        base._flightSpeed = _flightSpeed;

        _damagePoints = Mathf.Max(_damagePoints, data.damagePoints);
        base._damagePoints = _damagePoints;

        _damageFrequency = Mathf.Max(_damageFrequency, data.damageFrequency);
        base._damageFrequency = _damageFrequency;
    }
}
