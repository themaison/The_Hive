using UnityEngine;

public class BeeWarrior : Bee
{
    private static int _beeWarriorCounter;
    public static int BeeWarriorCounter
    {
        get { return _beeWarriorCounter; }
        set { _beeWarriorCounter = value; }
    }

    [SerializeField] private int _damagePoints;  // кол-во наносимого урон
    [SerializeField] private float _detectionRange = 10f;    // радиус обнаружени€ врагов

    private Enemy _enemyTarget;    // ближайший враг
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

    private void SearchTarget()    // ѕоиск близжайшего врага
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();  // получаем все объекты класса врага
        //”честь шершн€
        float closestDistance = Mathf.Infinity; // начальное значение рассто€ни€ до ближайшей осы

        foreach (Enemy et in enemies)
        {
            float distance = Vector2.Distance(transform.position, et.transform.position); // рассто€ние до текущей осы
            if (distance < closestDistance && distance <= _detectionRange)
            {
                closestDistance = distance; // обновл€ем ближайшее рассто€ние
                _enemyTarget = et; // обновл€ем цель
            }
        }
    }

    protected override void Fly()  // Ћететь к ближайшему врагу
    {
        if (_enemyTarget == null) SearchTarget();    // поиск новой цели
        Vector2 direction;  // направление к цели

        // ѕроверка достижени€ целии
        if (_enemyTarget != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTarget.transform.position);  // рассто€ние до цели
            if (distance <= 0.5) { Bite(_enemyTarget); }  // уничтожение врага
        }

        // выбор направлени€ - к цели или в улей
        if (_enemyTarget != null)
        {
            _spriteRenderer.flipX = _enemyTarget.transform.position.x >= transform.position.x;
            direction = _enemyTarget.transform.position - transform.position;
        }
        else    // если цели нет - летим в улей
        {
            _spriteRenderer.flipX = transform.position.x < 0;
            Vector2 hiveTarget = new Vector2(-0.35f, -0.5f);
            direction = hiveTarget - (Vector2)transform.position;
        }

        // двигатьс€ в направлении цели
        transform.Translate(direction.normalized * _flightSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) // исчезает в улье
    {
        if (collision.gameObject.tag == "hive")
        {
            _spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // по€вл€етс€ при вылете из уль€
    {
        if (collision.gameObject.tag == "hive")
        {
            _spriteRenderer.enabled = true;
        }
    }
}