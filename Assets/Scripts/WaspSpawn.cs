using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject WaspObj;
    public float spawnInterval = 1f;
    private float timer = 0f;

    private void Spawn()
    {
        // ����������� ������ �� �����, ��������� � ���������� �����
        timer += Time.deltaTime;
        
        // ���������, ������ �� ���������� ������� ��� ������ ������ �������
        if (timer >= spawnInterval)
        {
            // ������� ����� ������ �� ��������� ������� � � ��������� ���������
            Instantiate(WaspObj, Position(), Quaternion.identity);

            // ���������� ������
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
