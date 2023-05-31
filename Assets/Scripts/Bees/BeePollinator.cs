using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeePollinator : Bee
{
    public static int beePollinatorAmount;

    [SerializeField] private BeePollinatorData _beePollinatorData;

    private SpriteRenderer _spriteRenderer;
    private Flower _nearestFlower;

    new private static int _maxHealthPoints = 0;
    new private static int _maxSatietyPoints = 0;
    new private static float _flightSpeed = 0;
    private static int _nectarCapacity = 0;
    private static float _NCR = 0; // nectar collection rate

    private Animator anim;
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
    public static int NectarCapacity
    {
        get { return _nectarCapacity; }
        set { _nectarCapacity = value; }
    }
    public static float NCR
    {
        get { return _NCR; }
        set { _NCR = value; }
    }

    private bool _isCollecting;
    private float _collectingTime = 0f;
    private int _nectarOccupancy = 0;
    private Vector2 _targetPosition;

    private void Start()
    {
        LoadData(_beePollinatorData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _isCollecting = false;

        _currentHealthPoints = _maxHealthPoints;
        _currentSatietyPoints = _maxSatietyPoints;

        SetHintPanelSettings();
        UpdateHungerProcess(_hungerDelay);
        UpdateEatingProcess(_eatDelay);

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_nearestFlower == null)
        {
            FindNearestFlower();
        }

        if (_nearestFlower != null)
        {
            _nearestFlower.gameObject.tag = "flower_busy";

            float nearestDistance = Vector2.Distance(transform.position, _nearestFlower.transform.position);        
            if (nearestDistance < 0.1f)
            {
                CollectNectar(_nearestFlower);
            }
        }
        if (_nectarOccupancy > 0)
        {
            anim.SetBool("isPollen", true);
        }
        else
        {
            anim.SetBool("isPollen", false);
        }

        Fly();
        Regenerate();
        SpriteRender();
    }

    protected override void Fly()
    {
        if (_nectarOccupancy < _nectarCapacity && _nearestFlower != null && !_isCollecting)
        {
            _targetPosition = _nearestFlower.transform.position;
        }

        if (_nearestFlower == null)
        {
            if (_nectarOccupancy > 0)
            {
                _targetPosition = _hive.transform.position;
            }
            else
            {
                _targetPosition = transform.position;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _flightSpeed * Time.deltaTime);
    }

    private void FindNearestFlower()
    {

        Flower[] flowers = FindObjectsOfType<Flower>();

        float minDistance = Mathf.Infinity;
        foreach (Flower flower in flowers)
        {
            int flowerPollenAmount = flower.GetComponent<Flower>().PollenCount;

            if (flowerPollenAmount != 0)
            {
                float distance = Vector2.Distance(transform.position, flower.transform.position);
                int futureNectar = _nectarOccupancy + flowerPollenAmount;

                if (flower.gameObject.tag == "flower" && futureNectar <= _nectarCapacity && distance < minDistance)
                {
                    minDistance = distance;
                    _nearestFlower = flower;
                }
            }
        }
    }

    private void CollectNectar(Flower _flower)
    {
        _isCollecting = true;

        if (_collectingTime < _NCR)
        {
            _collectingTime += Time.deltaTime;
        }

        else
        {
            _nectarOccupancy += _flower.GetComponent<Flower>().PollenCount;

            Destroy(_flower.gameObject);
            Flower.FlowersCount -= 1;
            _flower = null;

            _collectingTime = 0;
            _isCollecting = false;
        }
    }

    private void SpriteRender()
    {
        _spriteRenderer.flipX = _targetPosition.x >= transform.position.x;
    }

    private void LoadData(BeePollinatorData data)
    {
        _name = data.name;

        _maxHealthPoints = Mathf.Max(_maxHealthPoints, data.healthPoints);
        base._maxHealthPoints = _maxHealthPoints;

        _maxSatietyPoints = Mathf.Max(_maxSatietyPoints, data.satietyPoints);
        base._maxSatietyPoints = _maxSatietyPoints;

        _flightSpeed = Mathf.Max(_flightSpeed, data.flightSpeed);
        base._flightSpeed = _flightSpeed;

        _NCR = Mathf.Max(_NCR, data.NCR);
        _nectarCapacity = Mathf.Max(_nectarCapacity, data.nectarCapacity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive" && _nectarOccupancy > 0)
        {
            _hive.AddNectar(_nectarOccupancy);
            _nectarOccupancy = 0;
        }
    }
}
