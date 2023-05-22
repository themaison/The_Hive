using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private Barrel _barrel;
    [SerializeField] private Transform _spawnCenterPosition;

    [Range(1.0f, 10.0f)]
    [SerializeField] private float _barrelSpawnRadius = 4.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public Barrel SpawnBarrel()
    {
        Barrel barrel = Instantiate(_barrel, RandomCircle(_spawnCenterPosition.position), Quaternion.identity);
        return barrel;
    }

    private Vector2 RandomCircle(Vector2 center)
    {
        float ang = Random.value * 360;

        Vector2 pos;
        pos.x = center.x + _barrelSpawnRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + _barrelSpawnRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
