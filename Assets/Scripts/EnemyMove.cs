using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;  // ������� ������, � �������� ��������
    public float amplitude = 1f;  // ��������� ���������
    public float frequency = 1f;  // ������� ���������
    public float speed = 1f;      // �������� ��������

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (targetObject != null)
        {
            // ��������� ����������� � �������� �������
            Vector3 directionToTarget = (targetObject.transform.position - transform.position).normalized;

            // ��������� ����� �������, �������� � ����������� ����
            Vector3 newPosition = transform.position + directionToTarget * speed * Time.deltaTime;

            // ��������� ����� �������
            transform.position = newPosition;
        }
        else
        {
            // ��������� ����� ������� �� ���������
            float yOffset = amplitude * Mathf.Sin(frequency * Time.time * speed);
            Vector3 newPosition = startPos + new Vector3(0f, yOffset, 0f);

            // ��������� ����� �������
            transform.position = newPosition;
        }
    }

    // ����� ��� ��������� �������� �������
    public void SetTarget(GameObject target)
    {
        targetObject = target;
    }
}