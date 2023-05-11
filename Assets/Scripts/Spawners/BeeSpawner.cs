using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private Bee _pollinator;
    [SerializeField] private Bee _warrior;
    [SerializeField] private Bee _recycler;

    [Range(1, 10)]
    [SerializeField] private float _spawnRadius = 1f;


    private Bee SpawnBee(Bee _bee, Vector2 _spawnPos)
    {
        Bee.BeeCounter += 1;

        _spawnPos = this.transform.position + Random.insideUnitSphere * _spawnRadius;
        Bee bee = Instantiate(_bee, _spawnPos, Quaternion.identity);
        bee.transform.SetParent(this.transform);

        return bee;
    }

    public void SpawnPollinator()
    {
        BeePollinator.BeePollinatorCounter += 1;

        SpawnBee(_pollinator, Vector2.zero);
    }

    public void SpawnWarrior()
    {
        BeeWarrior.BeeWarriorCounter += 1;

        SpawnBee(_warrior, Vector2.zero);
    }

    public void SpawnRecycler()
    {
        BeeRecycler.BeeRecyclerCounter += 1;

        float x = Random.Range(3, 8);
        float y = Random.Range(-3, 3);
        Vector2 spawnPos = new Vector2(x, y);

        SpawnBee(_recycler, spawnPos);
    }

    void Update()
    {
        
    }

    private void Start()
    {

    }
}
