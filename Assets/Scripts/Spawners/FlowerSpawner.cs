using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _flowers;

    [SerializeField]
    [Range(1f, 10f)]
    private float _forbiddenSpawnRadius;
    [SerializeField]
    [Range(2f, 15f)]
    private float _maxSpawnRadius;
    [SerializeField]
    [Range(0f, 10f)]
    private float _spawnDelay;
    private float _nextSpawnTime;
    [SerializeField]
    [Range(1, 100)]
    private int _spawnLimit;
    private int _spawnCounter;
    private Vector2 _spawnPosition;
    [SerializeField]
    [Range(1, 5)]
    private int _startFlowerCount;


    private int[] placementProbability = { 0, 1, 0, 0, 0, 1, 1, 0, 2, 0 };

    void Start()
    {
        for (int i = 0; i < _startFlowerCount;++i)
        {
            SpawnFlower();
        }

        _spawnCounter = _startFlowerCount;
        _nextSpawnTime = 0;
    }

    private void SpawnFlower()
    {
        bool isRing = false;
        do
        {
            _spawnPosition = GetRandSpawnPosition();
            isRing = Mathf.Pow(_spawnPosition.x, 2) + Mathf.Pow(_spawnPosition.y, 2) > Mathf.Pow(_forbiddenSpawnRadius, 2);

        } while (isRing == false);

        GameObject randFlower = GetRandFlowerObject();
        var obj = Instantiate(randFlower, _spawnPosition, Quaternion.identity);
        obj.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        _nextSpawnTime += Time.deltaTime;
        if (_nextSpawnTime >= _spawnDelay)
        {
            SpawnFlower();
            _spawnCounter++;
            _nextSpawnTime = 0f;
        }

        //// Проверка, достигнут ли лимит объектов
        //if (_spawnCounter >= _spawnLimit)
        //    return;

        //// Проверка, прошла ли нужная задержка между спавнами
        //else if (Time.time >= _nextSpawnTime)
        //{
        //    // Спавн объекта и обновление времени следующего
        //    SpawnFlower();

        //    _nextSpawnTime = Time.time + _spawnDelay;
        //    _spawnCounter++;
        //}
    }

    private Vector2 GetRandSpawnPosition()
    {
        float randX = Random.Range(-_maxSpawnRadius, _maxSpawnRadius + 1);
        float randY = Random.Range(-_maxSpawnRadius, _maxSpawnRadius + 1);
        return new Vector2(randX, randY);
    }

    private GameObject GetRandFlowerObject()
    {
        int randInx = placementProbability[Random.Range(0, placementProbability.Length)];
        return _flowers[randInx];
    }
}
