using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private Flower[] _flowers;
    [Range(1, 50)]
    [SerializeField] private int _startFlowerCount;
    [Range(1, 100)]
    [SerializeField] private int _spawnLimit;

    [Range(1f, 10f)]
    [SerializeField] private float _forbiddenSpawnRadius;
    [Range(2f, 15f)]
    [SerializeField] private float _maxSpawnRadius;
    [Range(0f, 10f)]
    [SerializeField] private float _spawnDelay;

    private Vector2 _spawnPosition;
    private float _nextSpawnTime = 0;
    private int _spawnCounter;


    private int[] placementProbability = { 0, 1, 0, 0, 0, 1, 1, 0, 2, 0 };

    private void Awake()
    {
        if (_spawnLimit < _startFlowerCount)
            _startFlowerCount = _spawnLimit;
    }

    private void Start()
    {

        for (int i = 0; i < _startFlowerCount;++i)
            SpawnFlower();

        _spawnCounter = _startFlowerCount;
    }


    void Update()
    {
        if (_spawnCounter < _spawnLimit)
        {
            //spawner timer
            _nextSpawnTime += Time.deltaTime;
            if (_nextSpawnTime >= _spawnDelay)
            {
                SpawnFlower();
                _spawnCounter++;
                _nextSpawnTime = 0f;
            }
        }
    }

    private void SpawnFlower()
    {
        bool isRing = false;
        do
        {
            //renerate random position
            _spawnPosition = transform.position + Random.insideUnitSphere * _maxSpawnRadius;
            isRing = Mathf.Pow(_spawnPosition.x, 2) + Mathf.Pow(_spawnPosition.y, 2) > Mathf.Pow(_forbiddenSpawnRadius, 2);

        } while (isRing == false);

        Flower randFlower = GetRandFlower();
        var obj = Instantiate(randFlower, _spawnPosition, Quaternion.identity);
        obj.transform.SetParent(transform);
    }

    private Flower GetRandFlower()
    {
        int randInx = placementProbability[Random.Range(0, placementProbability.Length)];
        return _flowers[randInx];
    }
}
