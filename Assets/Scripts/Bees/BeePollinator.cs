using UnityEngine;

public class BeePollinator : Bee
{
    public static int beePollinatorAmount;

    [SerializeField] private BeePollinatorData _beePollinatorData;

    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _pollinatedSprite;

    private SpriteRenderer _spriteRenderer;
    private Hive _hive;
    private Flower _nearestFlower;

    new private static int _maxHealthPoints;
    new private static int _maxSatietyPoints;
    new private static float _flightSpeed;
    private static int _nectarCapacity;
    private static float _NCR; // nectar collection rate

    private bool _isCollecting;
    private float _collectingTime = 0f;
    private int _nectarOccupancy = 0;
    private Vector2 _targetPosition;

    private void Start()
    {
        SetBeePollinatorStats(_beePollinatorData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _isCollecting = false;

        _currentHealthPoints = _maxHealthPoints;
        _currentSatietyPoints = _maxSatietyPoints;

        SetHintPanelSettings();
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

        Fly();
        SpriteRender();
    }

    protected override void Fly()
    {
        if (_nearestFlower != null && !_isCollecting)
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
            float distance = Vector2.Distance(transform.position, flower.transform.position);
            int futureNectar = _nectarOccupancy + flower.GetComponent<Flower>().PollenCount;

            if (flower.gameObject.tag == "flower" && futureNectar <= _nectarCapacity && distance < minDistance)
            {
                minDistance = distance;
                _nearestFlower = flower;
            }
        }
    }

    private void CollectNectar(Flower _flower)
    {
        //_flower.gameObject.tag = "flower_busy";
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
        if (_nectarOccupancy > 0)
        {
            _spriteRenderer.sprite = _pollinatedSprite;
        }
        else
        {
            _spriteRenderer.sprite = _defaultSprite;
        }

        _spriteRenderer.flipX = _targetPosition.x >= transform.position.x;
    }

    private void SetBeePollinatorStats(BeePollinatorData data)
    {
        _name = data.name;
        _maxHealthPoints = data.healthPoints;
        _maxSatietyPoints  = data.satietyPoints;
        _flightSpeed = data.flightSpeed;
        _HRR = data.HRR;
        _NCR = data.NCR;
        _nectarCapacity = data.nectarCapacity;
    }

    public static void UpdateBeePollinatorStats(BeePollinatorData data)
    {
        _maxHealthPoints = data.healthPoints;
        _maxSatietyPoints = data.satietyPoints;
        _flightSpeed = data.flightSpeed;
        _NCR = data.NCR;
        _nectarCapacity = data.nectarCapacity;
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
