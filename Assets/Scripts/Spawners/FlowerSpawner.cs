using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private Flower[] _flowers;
    [Range(1, 100)]
    [SerializeField] private int _startFlowerCount;
    [Range(1, 500)]
    [SerializeField] private int _spawnLimit;

    [Range(1f, 10f)]
    [SerializeField] private float _forbiddenSpawnRadius;
    [Range(1f, 20f)]
    [SerializeField] private float _SpawnRadiusX;
    [Range(1f, 20f)]
    [SerializeField] private float _SpawnRadiusY;
    [Range(0f, 10f)]
    [SerializeField] private float _spawnDelay;

    private float _nextSpawnTime = 0;


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

        Flower.FlowersCount = _startFlowerCount;
    }


    private void Update()
    {
        if (Flower.FlowersCount < _spawnLimit)
        {
            _nextSpawnTime += Time.deltaTime;
            if (_nextSpawnTime >= _spawnDelay)
            {
                SpawnFlower();
                _nextSpawnTime = 0f;
            }
        }
    }

    private void SpawnFlower()
    {
        Flower flower = GetRandFlower();
        Vector2 _spawnPosition = RandomElipse(transform.position, _SpawnRadiusX, _SpawnRadiusY);
        
        var obj = Instantiate(flower, _spawnPosition, Quaternion.identity);
        obj.transform.SetParent(transform);
        Flower.FlowersCount += 1;
    }

    private Flower GetRandFlower()
    {
        int randInx = placementProbability[Random.Range(0, placementProbability.Length)];
        return _flowers[randInx];
    }

    private Vector2 RandomElipse(Vector2 center, float radiusX, float radiusY)
    {
        float ang = Random.value * 360;
        float randX = Random.Range(_forbiddenSpawnRadius, radiusX);
        float randY = Random.Range(_forbiddenSpawnRadius, radiusY);

        Vector2 pos;
        pos.x = center.x + randX * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + randY * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
