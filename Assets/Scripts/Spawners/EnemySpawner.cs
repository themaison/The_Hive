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
        // ����������� ������ �� �����, ��������� � ���������� �����
        timer += Time.deltaTime;
        // ���������, ������ �� ���������� ������� ��� ������ ������ �������
        if (timer >= _spawnInterval)
        {
            // ������� ����� ������ �� ��������� ������� � � ��������� ���������
            Instantiate(_wasp, Position(), Quaternion.identity);
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
