using UnityEngine;

public class Hornet : Enemy
{
    [SerializeField] protected EnemyData _enemyData;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        SetEnemyData(_enemyData);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _target = FindObjectOfType<Hive>().gameObject;

        _currentHealthPoints = _maxHealthPoints;

        SetHintPanelSettings();
    }

    private void Update()
    {
        Fly();
        _spriteRenderer.flipX = _target.transform.position.x >= transform.position.x;
    }

    protected override void Fly()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flightSpeed * Time.deltaTime);
    }
}
