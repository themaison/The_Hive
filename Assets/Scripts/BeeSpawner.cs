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
    public float spawnInterval = 1f;
    [Range(1, 10)]
    public float spawnRadius = 1f;  // радиус, в котором нужно спавнить объекты
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
        float x = Random.Range(2f, 8f);
        float y = Random.Range(-3f, 3f);
        Vector3 spawnPosition = new Vector3(x, y, 0f);

        // проверяем, не находится ли уже объект в радиусе спавна другого объекта
        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 10f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("SpawnedObject"))
            {
                // если найден объект с тегом "SpawnedObject", то генерируем новую позицию и повторяем проверку
                SpawnRecycler();
                return;
            }
        }*/

        // Создаем новый объект на указанной позиции и с указанным поворотом
        Instantiate(BeeRecyclerObj, spawnPosition, Quaternion.identity).tag = "SpawnedObject";
    }

    void Update()
    {
        // Увеличиваем таймер на время, прошедшее с последнего кадра
        timer += Time.deltaTime;

        // Проверяем, прошло ли достаточно времени для спавна нового объекта
        if (timer >= spawnInterval)
        {
            SpawnWarrior();

            // Сбрасываем таймер
            timer = 0f;
        }
    }
}
