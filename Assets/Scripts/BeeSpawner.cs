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
    public float spawnRadius = 1f;  // ������, � ������� ����� �������� �������
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
        float x = Random.Range(2f, 8f);
        float y = Random.Range(-3f, 3f);
        Vector3 spawnPosition = new Vector3(x, y, 0f);

        // ���������, �� ��������� �� ��� ������ � ������� ������ ������� �������
        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 10f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("SpawnedObject"))
            {
                // ���� ������ ������ � ����� "SpawnedObject", �� ���������� ����� ������� � ��������� ��������
                SpawnRecycler();
                return;
            }
        }*/

        // ������� ����� ������ �� ��������� ������� � � ��������� ���������
        Instantiate(BeeRecyclerObj, spawnPosition, Quaternion.identity).tag = "SpawnedObject";
    }

    void Update()
    {
        // ����������� ������ �� �����, ��������� � ���������� �����
        timer += Time.deltaTime;

        // ���������, ������ �� ���������� ������� ��� ������ ������ �������
        if (timer >= spawnInterval)
        {
            SpawnWarrior();

            // ���������� ������
            timer = 0f;
        }
    }
}
