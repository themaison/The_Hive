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
    private Rigidbody2D _rb;
    private Hive _hive;

    private Flower _nearestFlower;

    private bool _isCollecting;
    private bool _isCollected;

    private float _baseSpeed;
    private float _collectingTime = 0f;
    private int _nectar—ollectedCounter = 0;
    private Vector2 _targetPos;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _hive = FindObjectOfType<Hive>();

        _baseSpeed = _flightSpeed;
        _nectar—ollectedCounter = 0;

        _isCollecting = false;
        _isCollected = false;
    }

    private void Update()
    {
        if (_isCollecting == false && _nearestFlower == null)
            FindNearestFlower();

        else if (transform.position.Equals(_nearestFlower.transform.position))
            CollectNectar(_nearestFlower);

        Fly();

        SpriteController();
    }

    protected override void Fly()
    {
        if (_nearestFlower != null && _nearestFlower.gameObject.tag == "flower")
        {
            _targetPos = _nearestFlower.transform.position;
        }
        else
        {
            _targetPos = _hive.transform.position;
            _isCollected = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _flightSpeed * Time.deltaTime);
    }

    private void FindNearestFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();

        float minDistance = Mathf.Infinity;
        foreach (Flower flower in flowers)
        {
            float distance = Vector2.Distance(transform.position, flower.transform.position);
            int futureNectar = _nectar—ollectedCounter + flower.GetComponent<Flower>().PollenCount;

            if (distance < minDistance && flower.gameObject.tag == "flower" && futureNectar <= _nectarCapacity)
            {
                minDistance = distance;
                _nearestFlower = flower;
            }
        }
    }

    private void CollectNectar(Flower _flower)
    {
        _isCollecting = true;
        _flightSpeed = 0;
        _flower.gameObject.tag = "flower_busy";

        if (_collectingTime < _NCR)
        {
            _collectingTime += Time.deltaTime;
        }

        else
        {
            _nectar—ollectedCounter += _flower.GetComponent<Flower>().PollenCount;
            Debug.Log(_nectar—ollectedCounter);

            Destroy(_flower.gameObject);
            _flower = null;

            _collectingTime = 0;
            _isCollecting = false;
            _flightSpeed = _baseSpeed;
        }
    }

    private void SpriteController()
    {
        if (_nectar—ollectedCounter > 0)
            _sr.sprite = _pollinatedSprite;
        else 
            _sr.sprite = _defaultSprite;

        _sr.flipX = _targetPos.x >= transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive" && _nectar—ollectedCounter>0)
        {
            collision.gameObject.GetComponent<Hive>().AddNectar(_nectar—ollectedCounter);
            _nectar—ollectedCounter = 0;
            _isCollected = false;
        }
    }
}
