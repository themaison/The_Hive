using System.Collections;
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

    private SpriteRenderer _sr;
    private Rigidbody2D _rb;

    private Flower _nearestFlower;

    private bool _isCollecting;
    private float _baseSpeed;
    private float _collectingTime = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _baseSpeed = _flightSpeed;
        _isCollecting = false;
    }

    void FixedUpdate()
    {   
        if (_isCollecting == false)
        {
            FindNearestFlower();
        }
        Fly();
    }

    protected override void Fly()
    {
        if (_nearestFlower != null)
        {
            if (_nearestFlower.gameObject.tag == "flower")
            {
                _sr.flipX = _nearestFlower.transform.position.x >= this.transform.position.x;
                this.transform.position = Vector2.MoveTowards(transform.position, _nearestFlower.transform.position, _flightSpeed * Time.deltaTime);
            }

            if (this.transform.position.Equals(_nearestFlower.transform.position))
            {
                _isCollecting = true;
                _flightSpeed = 0;
                _nearestFlower.gameObject.tag = "flower_busy";

                if (_collectingTime < _NCR)
                    _collectingTime += Time.deltaTime;

                else
                {
                    CollectNectar(_nearestFlower);
                    _collectingTime = 0;
                    _isCollecting = false;
                    _flightSpeed = _baseSpeed;
                }
            }
        }
    }

    private void FindNearestFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();

        float minDistance = Mathf.Infinity;
        foreach (Flower f in flowers)
        {
            float distance = Vector2.Distance(this.transform.position, f.transform.position);
            if (distance < minDistance && f.gameObject.tag == "flower")
            {
                minDistance = distance;
                _nearestFlower = f;
            }
        }
    }

    private void CollectNectar(Flower _flower)
    {
        //Collecting
        Destroy(_flower.gameObject);
        _flower = null;
    }
}
