using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] private Bee _pollinator;
    [SerializeField] private Bee _warrior;
    [SerializeField] private Bee _recycler;

    [Range(1.0f, 10.0f)]
    [SerializeField] private float _spawnRadius = 1f;
    private Vector2 _spawnPos;

    private void Start()
    {

    }

    private void Update()
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

        Barrel barrel = GetComponent<BarrelSpawner>().SpawnBarrel();
        Bee beeRecycler =  SpawnBee(_recycler);
        beeRecycler.GetComponent<BeeRecycler>().InitBarrel(barrel);
    }
}
