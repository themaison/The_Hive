using UnityEngine;

public class BeeWarrior : Bee
{
    private static int _beeWarriorCounter;
    public static int BeeWarriorCounter
    {
        get { return _beeWarriorCounter; }
        set { _beeWarriorCounter = value; }
    }

    [SerializeField] private int _damagePoints;  // ���-�� ���������� ����
    [SerializeField] private float _detectionRange = 10f;    // ������ ����������� ������

    private Enemy _enemyTarget;    // ��������� ����
    private SpriteRenderer _spriteRenderer;

    void Start()    // Start is called before the first frame update
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()   // Update is called once per frame
    {
        Fly();
    }


    public void Bite(Enemy _enemy)
    {
        Destroy(_enemy.gameObject);
    }

    private void SearchTarget()    // ����� ����������� �����
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();  // �������� ��� ������� ������ �����
        //������ ������
        float closestDistance = Mathf.Infinity; // ��������� �������� ���������� �� ��������� ���

        foreach (Enemy et in enemies)
        {
            float distance = Vector2.Distance(transform.position, et.transform.position); // ���������� �� ������� ���
            if (distance < closestDistance && distance <= _detectionRange)
            {
                closestDistance = distance; // ��������� ��������� ����������
                _enemyTarget = et; // ��������� ����
            }
        }
    }

    protected override void Fly()  // ������ � ���������� �����
    {
        if (_enemyTarget == null) SearchTarget();    // ����� ����� ����
        Vector2 direction;  // ����������� � ����

        // �������� ���������� �����
        if (_enemyTarget != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTarget.transform.position);  // ���������� �� ����
            if (distance <= 0.5) { Bite(_enemyTarget); }  // ����������� �����
        }

        // ����� ����������� - � ���� ��� � ����
        if (_enemyTarget != null)
        {
            _spriteRenderer.flipX = _enemyTarget.transform.position.x >= transform.position.x;
            direction = _enemyTarget.transform.position - transform.position;
        }
        else    // ���� ���� ��� - ����� � ����
        {
            _spriteRenderer.flipX = transform.position.x < 0;
            Vector2 hiveTarget = new Vector2(-0.35f, -0.5f);
            direction = hiveTarget - (Vector2)transform.position;
        }

        // ��������� � ����������� ����
        transform.Translate(direction.normalized * _flightSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) // �������� � ����
    {
        if (collision.gameObject.tag == "hive")
        {
            _spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // ���������� ��� ������ �� ����
    {
        if (collision.gameObject.tag == "hive")
        {
            _spriteRenderer.enabled = true;
        }
    }
}