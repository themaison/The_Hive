using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _beePollinator;
    [SerializeField]
    private GameObject _beeWarrior;
    [SerializeField]
    private GameObject _beeRecycler;

    [SerializeField]
    [Range(1, 10)]
    private float spawnRadius = 1f;  // радиус, в котором нужно спавнить объекты
    //[SerializeField]
    //[Range(1, 10)]
    //private float _spawnDelay = 1f;
    //private float _nextSpawnTime = 0f;


    private GameObject SpawnBee(GameObject _bee, Vector2 _spawnPos)
    {
        Bee.beeCounter++;
        _spawnPos = this.transform.position + Random.insideUnitSphere * spawnRadius;
        var obj = Instantiate(_beePollinator, _spawnPos, Quaternion.identity);
        obj.transform.SetParent(this.transform);
        return obj;
    }

    public void SpawnPollinator()
    {
        BeePollinator.BeePollinatorCounter++;
        SpawnBee(_beePollinator, Vector2.zero);
    }

    public void SpawnWarrior()
    {
        SpawnBee(_beeWarrior, Vector2.zero);
    }

    public void SpawnRecycler()
    {
        float x = Random.Range(3, 8);
        float y = Random.Range(-3, 3);
        Vector2 spawnPos = new Vector2(x, y);
        SpawnBee(_beeRecycler, spawnPos);
    }

    void Update()
    {
        //_nextSpawnTime += Time.deltaTime;
        //if (_nextSpawnTime >= _spawnDelay)
        //{
        //    SpawnPollinator();
        //    _nextSpawnTime = 0f;
        //}
    }
}
