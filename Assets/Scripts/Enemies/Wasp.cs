using Unity.VisualScripting;
using UnityEngine;

public class Wasp : Enemy
{
    [SerializeField] protected EnemyData _waspData;

    new private static int _maxHealthPoints;
    new private static float _flightSpeed;
    new private static int _damagePoints;
    new private static float _damageFrequency;

    private Animator _takeDamageAnim;

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
    private Hive _hive;

    private float _damageTime = 0f;
    private float minDistance = 0f;

    private void Start()
    {
        LoadData(_waspData);

        _takeDamageAnim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        //_damageTime = _damageFrequency;
        _currentHealthPoints = _maxHealthPoints;

        SetHintPanelSettings();
    }

    private void Update()
    {
        FindNearestTarget();
        Fly();
    }

    protected override void Fly()
    {
        if (minDistance > 0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flightSpeed * Time.deltaTime);
            _spriteRenderer.flipX = _target.transform.position.x >= transform.position.x;
        }
        else if (_target.CompareTag("bee"))
        {
            Fight();
        }
        else if (_target.CompareTag("hive"))
        {
            Breaking();
        }
    }

    protected void Fight()
    {
        _takeDamageAnim.SetBool("TakeDamageWasp", true);
        if (Time.time - _damageTime > _damageFrequency)
        {
            if (_target.CompareTag("bee"))
            {
                Bite(_target.GetComponent<Bee>());
                _damageTime = Time.time;
            }
        }
        _takeDamageAnim.SetBool("TakeDamageWasp", false);
    }

    protected void Breaking()
    {
        if (Time.time - _damageTime > _damageFrequency)
        {
            if (_target.CompareTag("hive"))
            {
                Break(_target.GetComponent<Hive>());
                _damageTime = Time.time;
            }
        }
    }

    private void FindNearestTarget()
    {
        Bee[] bees = FindObjectsOfType<Bee>();

        minDistance = Mathf.Infinity;

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
