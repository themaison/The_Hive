using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BeeRecycler : Bee
{
    public static int beeRecyclerAmount;

    [SerializeField] private BeeRecyclerData _beeRecyclerData;

    new private static int _maxHealthPoints = 0;
    new private static int _maxSatietyPoints = 0;
    new private static float _flightSpeed = 0;
    private static int _productionEfficiency = 0;
    private static float _NPR = 0;

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

    public static int ProductionEfficiency
    {
        get { return _productionEfficiency; }
        set { _productionEfficiency = value; }
    }

    public static float NPR
    {
        get { return _NPR; }
        set { _NPR = value; }
    }

    private Animator anim;

    private Barrel _barrel;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _targetPosition;
    private bool _isRecycling;
    private bool _isHasHoney;

    private void Start()
    {
        LoadData(_beeRecyclerData);

        _hive = FindObjectOfType<Hive>();
        _spriteRenderer  = GetComponent<SpriteRenderer>();

        _isRecycling = false;
        _isHasHoney = false;
        _spriteRenderer.enabled = false;
        _currentHealthPoints = _maxHealthPoints;
        _currentSatietyPoints = _maxSatietyPoints;
        _flightSpeed = (Vector2.Distance(_hive.transform.position, _barrel.transform.position) / _NPR) * 2;

        SetHintPanelSettings();
        UpdateHungerProcess(_hungerDelay);
        UpdateEatingProcess(_eatDelay);

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isHoney", _isHasHoney);

        ProcessNectar();
        Fly();
        Regenerate();
        SpriteRender();
    }

    public void InitBarrel(Barrel barrel)
    {
        _barrel = barrel;
    }

    private void ProcessNectar()
    {
        if (!_isRecycling && Hive.NectarOccupancy > 0)
        {
            _hive.GetNectar(1);

            _isRecycling = true;
            _isHasHoney = true;
            _spriteRenderer.enabled = true;
            _targetPosition = _barrel.transform.position;
        }

        if (_isRecycling)
        {
            if (_isHasHoney)
            {
                float barrelDistance = Vector2.Distance(transform.position, _barrel.transform.position);
                if (barrelDistance < 0.1f)
                {
                    _barrel.AddHoney(1 * _productionEfficiency);
                    _isHasHoney = false;

                    _targetPosition = _hive.transform.position;
                }
            }
            else
            {
                float hiveDistance = Vector2.Distance(transform.position, _hive.transform.position);
                if (hiveDistance < 0.1f)
                {
                    _isRecycling = false;
                    _spriteRenderer.enabled = false;
                }
            }
        }
    }

    protected override void Fly()
    {
        if (_isRecycling)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _flightSpeed * Time.deltaTime);
        }
    }

    protected override void Die()
    {
        base.Die();
        Destroy(_barrel.gameObject);
    }

    private void SpriteRender()
    {
        _spriteRenderer.flipX = _targetPosition.x >= transform.position.x;
    }

    public void LoadData(BeeRecyclerData data)
    {
        _name = data.name;

        _maxHealthPoints = Mathf.Max(_maxHealthPoints, data.healthPoints);
        base._maxHealthPoints = _maxHealthPoints;

        _maxSatietyPoints = Mathf.Max(_maxSatietyPoints, data.satietyPoints);
        base._maxSatietyPoints = _maxSatietyPoints;

        _flightSpeed = Mathf.Max(_flightSpeed, data.flightSpeed);
        base._flightSpeed = _flightSpeed;

        _NPR = Mathf.Max(_NPR, data.NPR);

        _productionEfficiency = Mathf.Max(_productionEfficiency, data.productionEfficiency);
    }
}
