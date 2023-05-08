using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject BeePollinatorObj;
    [SerializeField]
    private GameObject BeeWarriorObj;
    [SerializeField]
    private GameObject BeeRecyclerObj;
    [SerializeField]
    [Range(1, 10)]
    private float spawnRadius = 1f;  // радиус, в котором нужно спавнить объекты
    [SerializeField]
    private float spawnInterval = 1f;
    private float timer = 0f;

    // Спавн пчёл-собирателей
    private void SpawnPollinator()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        // Создаем новый объект на указанной позиции и с указанным поворотом
        Instantiate(BeePollinatorObj, spawnPosition, Quaternion.identity);
    }

    // Спавн пчёл-воинов
    private void SpawnWarrior()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        // Создаем новый объект на указанной позиции и с указанным поворотом
        Instantiate(BeeWarriorObj, spawnPosition, Quaternion.identity);
    }

    // Спавн пчёл-переработчиков
    private void SpawnRecycler()
    {
        float x = Random.Range(3, 8);
        float y = Random.Range(-3, 3);
        Vector2 spawnPosition = new Vector2(x, y);

        // Создаем новый объект на указанной позиции и с указанным поворотом
        Instantiate(BeeRecyclerObj, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        // Увеличиваем таймер на время, прошедшее с последнего кадра
        timer += Time.deltaTime;

        // Проверяем, прошло ли достаточно времени для спавна нового объекта
        if (timer >= spawnInterval)
        {
            SpawnRecycler();

            // Сбрасываем таймер
            timer = 0f;
        }
    }
}
