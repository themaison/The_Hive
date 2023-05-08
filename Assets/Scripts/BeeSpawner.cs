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
    private float spawnRadius = 1f;  // ������, � ������� ����� �������� �������
    [SerializeField]
    private float spawnInterval = 1f;
    private float timer = 0f;

    // ����� ����-�����������
    private void SpawnPollinator()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        // ������� ����� ������ �� ��������� ������� � � ��������� ���������
        Instantiate(BeePollinatorObj, spawnPosition, Quaternion.identity);
    }

    // ����� ����-������
    private void SpawnWarrior()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

        // ������� ����� ������ �� ��������� ������� � � ��������� ���������
        Instantiate(BeeWarriorObj, spawnPosition, Quaternion.identity);
    }

    // ����� ����-��������������
    private void SpawnRecycler()
    {
        float x = Random.Range(3, 8);
        float y = Random.Range(-3, 3);
        Vector2 spawnPosition = new Vector2(x, y);

        // ������� ����� ������ �� ��������� ������� � � ��������� ���������
        Instantiate(BeeRecyclerObj, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        // ����������� ������ �� �����, ��������� � ���������� �����
        timer += Time.deltaTime;

        // ���������, ������ �� ���������� ������� ��� ������ ������ �������
        if (timer >= spawnInterval)
        {
            SpawnRecycler();

            // ���������� ������
            timer = 0f;
        }
    }
}
