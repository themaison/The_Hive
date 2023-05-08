using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] flowers;

    [SerializeField]
    [Range(1f, 10f)]
    private float forbiddenRadius;
    [SerializeField]
    [Range(2f, 15f)]
    private float maxRadius;
    [SerializeField]
    [Range(0f, 10f)]
    private float spawnDelay;
    private float nextSpawnTime;
    [SerializeField]
    [Range(1, 500)]
    private int spawnLimit;
    private int spawnCounter;
    private Vector2 spawnPosition;

    private int[] placementProbability = { 0, 1, 0, 0, 0, 1, 1, 0, 2, 0 };

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
            // Спавн объекта и обновление времени следующего
            bool isRing = false;
            do
            {
                spawnPosition = GetRandSpawnPosition();
                isRing = Mathf.Pow(spawnPosition.x, 2) + Mathf.Pow(spawnPosition.y, 2) > Mathf.Pow(forbiddenRadius, 2);

            } while (isRing == false);

            GameObject randFlower = GetRandFlowerObject();
            var obj = Instantiate(randFlower, spawnPosition, Quaternion.identity);
            obj.transform.SetParent(this.transform);

            nextSpawnTime = Time.time + spawnDelay;
            spawnCounter++;
        }
    }

    private Vector2 GetRandSpawnPosition()
    {
        float randX = Random.Range(-maxRadius, maxRadius + 1);
        float randY = Random.Range(-maxRadius, maxRadius + 1);
        return new Vector2(randX, randY);
    }

    private GameObject GetRandFlowerObject()
    {
        int randInx = placementProbability[Random.Range(0, placementProbability.Length)];
        // Debug.Log(randInx);
        return flowers[randInx];
    }
}
