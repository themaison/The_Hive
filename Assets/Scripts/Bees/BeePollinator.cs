using UnityEngine;

public class BeePollinator : Bee
{
    private static int _beePollinatorCounter;
    public static int BeePollinatorCounter
    {
        get { return _beePollinatorCounter; }
        set { _beePollinatorCounter = value; }
    }

    [SerializeField] private int _nectarCapacity;
    [SerializeField] private int _NCR; // nectar collection rate
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _pollinatedSprite;

    private SpriteRenderer _sr;
    private Hive _hive;

    private Flower _nearestFlower;

    private bool _isCollecting;

    private float _collectingTime = 0f;
    private int _nectarOccupancy = 0;
    private Vector2 _targetPosition;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _isCollecting = false;
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
        SpriteController();
    }

    protected override void Fly()
    {
        if (_nearestFlower != null && !_isCollecting)
        {
            //if (_nearestFlower.gameObject.tag == "flower_busy")
            //{
            //    _nearestFlower = null;
            //    return;
            //}

            //else
            //{
            //    _targetPosition = _nearestFlower.transform.position;
            //}
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
        _flower.gameObject.tag = "flower_busy";
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

    private void SpriteController()
    {
        if (_nectarOccupancy > 0)
        {
            _sr.sprite = _pollinatedSprite;
        }
        else
        {
            _sr.sprite = _defaultSprite;
        }

        _sr.flipX = _targetPosition.x >= transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive" && _nectarOccupancy>0)
        {
            collision.gameObject.GetComponent<Hive>().AddNectar(_nectarOccupancy);
            _nectarOccupancy = 0;
        }
    }
}
