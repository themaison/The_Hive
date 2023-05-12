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
    [SerializeField] private float _detectionRange = 10f;    // радиус обнаружения врагов

    private Enemy _enemyTarget;    // ближайший враг
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

    private void SearchTarget()    // Поиск близжайшего врага
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();  // получаем все объекты класса врага
        //Учесть шершня


        float closestDistance = Mathf.Infinity; // начальное значение расстояния до ближайшей осы

        foreach (Enemy et in enemies)
        {
            float distance = Vector2.Distance(transform.position, et.transform.position); // расстояние до текущей осы
            if (distance < closestDistance && distance <= _detectionRange)
            {
                closestDistance = distance; // обновляем ближайшее расстояние
                _enemyTarget = et; // обновляем цель
            }
        }
    }

    protected override void Fly()  // Лететь к ближайшему врагу
    {
        if (_enemyTarget == null) 
            SearchTarget();    // поиск новой цели

        // Проверка достижения цели
        if (_enemyTarget != null)
        {
            float distance = Vector2.Distance(transform.position, _enemyTarget.transform.position);  // расстояние до цели
            if (distance <= 0.5) { Bite(_enemyTarget); }  // уничтожение врага
        }

        // выбор направления - к цели или в улей
        if (_enemyTarget != null)
        {
           //_spriteRenderer.flipX = _enemyTarget.transform.position.x >= transform.position.x;
            targetPos = _enemyTarget.transform.position;
        }
        else    // если цели нет - летим в улей
        {
            //_spriteRenderer.flipX = transform.position.x <= _hive.transform.position.x;
            targetPos = _hive.transform.position;
        }

        // двигаться в направлении цели
        transform.position = Vector2.MoveTowards(transform.position, targetPos, _flightSpeed * Time.deltaTime);
        //transform.Translate(targetPos.normalized * _flightSpeed * Time.deltaTime);
        //_spriteRenderer.flipX = transform.position.x < targetPos.x;
    }

    private void OnTriggerEnter2D(Collider2D collision) // исчезает в улье
    {
        if (collision.gameObject.tag == "hive")
        {
            //_spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // появляется при вылете из улья
    {
        if (collision.gameObject.tag == "hive")
        {
            //_spriteRenderer.enabled = true;
        }
    }
}