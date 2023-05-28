using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BeeRecycler : Bee
{
    public static int beeRecyclerAmount;

    [SerializeField] private BeeRecyclerData _beeRecyclerData;

    private int _productionEfficiency;
    private float _NPR; //nectar processing rate


    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _honeySprite;

    private Barrel _barrel;
    private SpriteRenderer _spriteRenderer;
    private Hive _hive;

    private Vector2 _targetPosition;
    private bool _isRecycling;
    private bool _isHasHoney;

    private void Start()
    {
        SetBeeRecyclerStats(_beeRecyclerData);

        _hive = FindObjectOfType<Hive>();
        _spriteRenderer  = GetComponent<SpriteRenderer>();

        _isRecycling = false;
        _isHasHoney = false;
        _spriteRenderer.enabled = false;
        _currentHealthPoints = _maxHealthPoints;
        _currentSatietyPoints = _maxSatietyPoints;
        _flightSpeed = (Vector2.Distance(_hive.transform.position, _barrel.transform.position) / _NPR) * 2;

        SetHintPanelSettings();
    }

    private void Update()
    {
        ProcessNectar();
        Fly();
        SpriteRender();
    }

    public void InitBarrel(Barrel barrel)
    {
        _barrel = barrel;
    }

    private void ProcessNectar()
    {
        if (!_isRecycling && _hive.GetComponent<Hive>().NectarOccupancy > 0)
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
        if (_isHasHoney)
        {
            _spriteRenderer.sprite = _honeySprite;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
        }

        _spriteRenderer.flipX = _targetPosition.x >= transform.position.x;
    }

    public void SetBeeRecyclerStats(BeeRecyclerData BRD)
    {
        _name = BRD.name;
        _maxHealthPoints = BRD.healthPoints;
        _maxSatietyPoints = BRD.satietyPoints;
        _flightSpeed = BRD.flightSpeed;
        _HRR = BRD.HRR;
        _NPR = BRD._NPR;
        _productionEfficiency = BRD.productionEfficiency;
    }
}
