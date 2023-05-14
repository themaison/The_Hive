using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Wasp _wasp;
    [SerializeField] private Hornet _hornet;

    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private float _spawnRadiusX = 15f;
    [SerializeField] private float _spawnRadiusY = 8f;

    private float _nextSpawnTime = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        _nextSpawnTime += Time.deltaTime;
        if (_nextSpawnTime >= _spawnDelay)
        {
            SpawnEnemy(_wasp);
            _nextSpawnTime = 0f;
        }
    }

    private void SpawnEnemy(Enemy enemy)
    {
        Vector2 _spawnPosition = RandomElipse(transform.position, _spawnRadiusX, _spawnRadiusY);

        var obj = Instantiate(enemy, _spawnPosition, Quaternion.identity);
        obj.transform.SetParent(transform);
        Flower.FlowersCount += 1;
    }

    private Vector2 RandomElipse(Vector2 center, float radiusX, float radiusY)
    {
        float ang = Random.value * 360;

        Vector2 pos;
        pos.x = center.x + radiusX * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radiusY * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
