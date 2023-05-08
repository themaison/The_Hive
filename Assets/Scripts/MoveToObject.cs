using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour
{
    public float speed = 1f;      // Скорость движения
    [SerializeField]
    private GameObject targetObject;  // Целевой объект, к которому движемся

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
    }

    // Метод для установки целевого объекта
    public void SetTarget(GameObject target)
    {
        targetObject = target;
    }
}
