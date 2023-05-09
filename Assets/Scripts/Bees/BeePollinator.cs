using System.Collections;
using UnityEngine;

public class BeePollinator : Bee
{
    private static int _beePollinatorCounter;
    [SerializeField]
    private int _nectarCapacity;
    [SerializeField]
    private int _NCR; // nectar collection rate
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;

    public static int BeePollinatorCounter
    {
        get { return _beePollinatorCounter; }
        set { _beePollinatorCounter = value;}
    }

    private GameObject _flowerSpawner;
    private GameObject _nearestFlower;

    private bool _isCollecting;
    private float _baseSpeed;
    private float _collectingTime = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _flowerSpawner = GameObject.Find("FlowerSpawner");
        _baseSpeed = _flightSpeed;
        _isCollecting = false;
    }

    // Update is called once per frame
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
                this.transform.position = Vector2.MoveTowards(transform.position, _nearestFlower.transform.position, base._flightSpeed * Time.deltaTime);
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
        Transform[] flowersTransfroms = _flowerSpawner.GetComponentsInChildren<Transform>();

        float minDistance = Mathf.Infinity;
        foreach (Transform flowerT in flowersTransfroms)
        {
            float distance = Vector2.Distance(this.transform.position, flowerT.position);
            if (distance < minDistance && flowerT.gameObject.tag == "flower")
            {
                minDistance = distance;
                _nearestFlower = flowerT.gameObject;
            }
        }
    }

    //IEnumerator CollectNectar(GameObject _flower)
    //{
    //    _flower.gameObject.tag = "flower_busy";

    //    yield return new WaitForSeconds(_NCR);
    //    //Collecting

    //    Destroy(_flower);
    //    _flower = null;
    //}

    private void CollectNectar(GameObject _flower)
    {
        //Collecting
        Destroy(_flower);
        _flower = null;
    }
}
