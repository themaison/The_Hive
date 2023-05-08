using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;  // Целевой объект, к которому движемся
    public float amplitude = 1f;  // Амплитуда синусоиды
    public float frequency = 1f;  // Частота синусоиды
    public float speed = 1f;      // Скорость движения

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // Вычисляем направление к целевому объекту
            Vector3 directionToTarget = (targetObject.transform.position - transform.position).normalized;

            // Вычисляем новую позицию, двигаясь в направлении цели
            Vector3 newPosition = transform.position + directionToTarget * speed * Time.deltaTime;

            // Применяем новую позицию
            transform.position = newPosition;
        }
        else
        {
            // Вычисляем новую позицию по синусоиде
            float yOffset = amplitude * Mathf.Sin(frequency * Time.time * speed);
            Vector3 newPosition = startPos + new Vector3(0f, yOffset, 0f);

            // Применяем новую позицию
            transform.position = newPosition;
        }
    }

    // Метод для установки целевого объекта
    public void SetTarget(GameObject target)
    {
        targetObject = target;
    }
}