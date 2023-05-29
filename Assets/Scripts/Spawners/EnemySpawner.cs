using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Wasp _wasp;
    [SerializeField] private Hornet _hornet;

    [SerializeField] private Text _waveCountText;
    [SerializeField] private Text _waveTimerText;

    [SerializeField] private float _spawnRadiusX;
    [SerializeField] private float _spawnRadiusY;

    [Range(0.1f, 5.0f)]
    [SerializeField] private float _waspSpawnDelay;
    [Range(5.0f, 120.0f)]
    [SerializeField] private float _waveDelay;

    [Serializable]
    private class Wave
    {
        public Enemy enemy;
        public int count;
    }

    [SerializeField]
    private Wave[] _waves;

    private Wave _currentWave;

    private float _nextWaveTime = 0f;
    private int _currentWaveIndex = 0;

    private float _nextSpawnTime = 0f;
    private int _currentSpawnCount = 0;

    private bool _isPreparing = true;
    private bool _isWaveActive = false;



    private void Awake()
    {
        _waves = new Wave[]
        {
            new Wave { enemy = _wasp, count = 2 },
            new Wave { enemy = _wasp, count = 4 },
            new Wave { enemy = _wasp, count = 7 },
            new Wave { enemy = _wasp, count = 11 },
            new Wave { enemy = _wasp, count = 15 },
            new Wave { enemy = _hornet, count = 1 },
        };
    }

    private void Start()
    {
        _nextWaveTime = _waveDelay;
    }

    private void Update()
    {
        if (Time.time >= _nextWaveTime)
        {
            WaveProcess();
            _nextWaveTime = Time.time + _waveDelay;
        }

        float timeLeft = Mathf.Clamp(_nextWaveTime - Time.time, 0f, _waveDelay);
        _waveTimerText.text = "����. ����� ����� " + Mathf.CeilToInt(timeLeft).ToString() + " ���";

        if (_isPreparing)
        {
            _waveCountText.text = "����������";
            _waveTimerText.enabled = true;
        }
        else if (_isWaveActive)
        {
            _waveCountText.text = "����� " + (_currentWaveIndex + 1).ToString();
            _waveTimerText.enabled = true;
        }
        else if (_currentWaveIndex >= _waves.Length - 1)
        {
            _waveCountText.text = "����";
            _waveTimerText.enabled = false;
        }
    }

    private void WaveProcess()
    {
        if (_currentWaveIndex >= _waves.Length)
        {
            return;
        }

        _currentWave = _waves[_currentWaveIndex];
        _currentSpawnCount = 0;
        _nextSpawnTime = Time.time;

        _isPreparing = false;
        _isWaveActive = true;
        SpawnNextEnemy();
    }

    private void SpawnNextEnemy()
    {
        if (_currentSpawnCount < _currentWave.count)
        {
            SpawnEnemy(_currentWave.enemy);
            _currentSpawnCount++;
            _nextSpawnTime += _waspSpawnDelay;
            Invoke("SpawnNextEnemy", _waspSpawnDelay);
        }
        else
        {
            _currentWaveIndex++;
            _isWaveActive = false;
        }
    }

    private void SpawnEnemy(Enemy enemy)
    {
        Vector2 spawnPosition = RandomEllipse(transform.position, _spawnRadiusX, _spawnRadiusY);

        var obj = Instantiate(enemy, spawnPosition, Quaternion.identity);
        obj.transform.SetParent(transform);
    }

    private Vector2 RandomEllipse(Vector2 center, float radiusX, float radiusY)
    {
        float angle = UnityEngine.Random.value * 360;

        Vector2 position;
        position.x = center.x + radiusX * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = center.y + radiusY * Mathf.Cos(angle * Mathf.Deg2Rad);
        return position;
    }
}