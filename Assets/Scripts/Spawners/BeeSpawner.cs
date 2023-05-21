using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private Bee _pollinator;
    [SerializeField] private Bee _warrior;
    [SerializeField] private Bee _recycler;

    [SerializeField] private Barrel _barrel;

    [Range(1.0f, 10.0f)]
    [SerializeField] private float _spawnRadius = 1f;
    [Range(1.0f, 10.0f)]
    [SerializeField] private float _barrelSpawnRadius = 4.0f;
    private Vector2 _spawnPos;

    private void Update()
    {

    }

    private void Start()
    {

    }

    private Bee SpawnBee(Bee _bee)
    {
        Bee.BeeCounter += 1;

        _spawnPos = this.transform.position + Random.insideUnitSphere * _spawnRadius;
        Bee bee = Instantiate(_bee, _spawnPos, Quaternion.identity);
        bee.transform.SetParent(transform);

        return bee;
    }

    public void SpawnPollinator()
    {
        BeePollinator.BeePollinatorCounter += 1;

        SpawnBee(_pollinator);
    }

    public void SpawnWarrior()
    {
        BeeWarrior.BeeWarriorCounter += 1;
  
        SpawnBee(_warrior);
    }

    public void SpawnRecycler()
    {
        BeeRecycler.BeeRecyclerCounter += 1;

        SpawnBarrel();
        SpawnBee(_recycler);
    }

    private Barrel SpawnBarrel()
    {
        Barrel barrel = Instantiate(_barrel, RandomElipse(Vector2.zero), Quaternion.identity);
        return barrel;
    }

    private Vector2 RandomElipse(Vector2 center)
    {
        float ang = Random.value * 360;

        Vector2 pos;
        pos.x = center.x + _barrelSpawnRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + _barrelSpawnRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
