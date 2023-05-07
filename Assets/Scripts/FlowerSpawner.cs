using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chamomileObj;
    [SerializeField]
    private GameObject violetObj;
    [SerializeField]
    private GameObject sunflowerObj;

    [SerializeField]
    [Range(1, 10)]
    private float forbiddenRadius;
    [SerializeField]
    [Range(2, 15)]
    private float maxRadius;
    [SerializeField]
    [Range(1, 10)]
    private float spawnDelay;
    private float nextSpawnTime;
    [SerializeField]
    [Range(1, 20)]
    private int spawnLimit;
    private int spawnCounter;

    void Start()
    {
        spawnCounter = 0;
        nextSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Проверка, достигнут ли лимит объектов
        if (spawnCounter >= spawnLimit)
            return;

        // Проверка, прошла ли нужная задержка между спавнами
        else if (Time.time >= nextSpawnTime)
        {
            // Спавн объекта и обновление времени следующего спавна
            Vector2 spawnPosition = GetRandSpawnPosition();
            Instantiate(sunflowerObj, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + spawnDelay;
            spawnCounter++;
        }
    }

    private Vector2 GetRandSpawnPosition()
    {
        float randX = Random.Range(-10, 10);
        float randY = Random.Range(-10, 10);
        Vector2 spawnPosition = new Vector2(randX, randY);
        return spawnPosition;
    }
}
