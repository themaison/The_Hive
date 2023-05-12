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
    private Hive _hive;
    private Vector2 targetPos;

    void Start()    // Start is called before the first frame update
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hive = FindAnyObjectByType<Hive>();
    }

    void Update()   // Update is called once per frame
    {
        Fly();
        _spriteRenderer.flipX = transform.position.x < targetPos.x;
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
        if (_enemyTarget == null) 
            SearchTarget();    // ����� ����� ����

        // �������� ���������� ����
        if (_enemyTarget != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTarget.transform.position);  // ���������� �� ����
            if (distance <= 0.5) { Bite(_enemyTarget); }  // ����������� �����
        }

        // ����� ����������� - � ���� ��� � ����
        if (_enemyTarget != null)
        {
           //_spriteRenderer.flipX = _enemyTarget.transform.position.x >= transform.position.x;
            targetPos = _enemyTarget.transform.position;
        }
        else    // ���� ���� ��� - ����� � ����
        {
            //_spriteRenderer.flipX = transform.position.x <= _hive.transform.position.x;
            targetPos = _hive.transform.position;
        }

        // ��������� � ����������� ����
        transform.position = Vector2.MoveTowards(transform.position, targetPos, _flightSpeed * Time.deltaTime);
        //transform.Translate(targetPos.normalized * _flightSpeed * Time.deltaTime);
        //_spriteRenderer.flipX = transform.position.x < targetPos.x;
    }

    private void OnTriggerEnter2D(Collider2D collision) // �������� � ����
    {
        if (collision.gameObject.tag == "hive")
        {
            //_spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // ���������� ��� ������ �� ����
    {
        if (collision.gameObject.tag == "hive")
        {
            //_spriteRenderer.enabled = true;
        }
    }
}