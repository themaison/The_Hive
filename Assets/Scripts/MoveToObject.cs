using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour
{
    public float speed = 1f;      // �������� ��������
    [SerializeField]
    private GameObject targetObject;  // ������� ������, � �������� ��������

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
    }

    // ����� ��� ��������� �������� �������
    public void SetTarget(GameObject target)
    {
        targetObject = target;
    }
}
