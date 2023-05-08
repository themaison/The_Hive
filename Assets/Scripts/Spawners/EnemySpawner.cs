using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _wasp;
    [SerializeField]
    private float _spawnInterval = 1f;
    private float timer = 0f;

    private void Spawn()
    {
        // Увеличиваем таймер на время, прошедшее с последнего кадра
        timer += Time.deltaTime;
        // Проверяем, прошло ли достаточно времени для спавна нового объекта
        if (timer >= _spawnInterval)
        {
            // Создаем новый объект на указанной позиции и с указанным поворотом
            Instantiate(_wasp, Position(), Quaternion.identity);
            // Сбрасываем таймер
            timer = 0f;
        }
    }
    
    Vector2 Position()
    {
        float randY = Random.Range(-5, 5);
        Vector2 pos = new Vector2(this.transform.position.x, randY);
        return pos;
    }

    void Update()
    {
        Spawn();
    }
}
