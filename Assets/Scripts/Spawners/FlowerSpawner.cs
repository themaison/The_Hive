using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _flowers;
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
    private float _nextSpawnTime;
    private int _spawnCounter;


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
