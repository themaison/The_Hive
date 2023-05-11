using UnityEngine;

public class Wasp : Enemy
{
    //[SerializeField]
    //private float _amplitude = 1f;  // Амплитуда синусоиды
    //[SerializeField]
    //private float _frequency = 1f;  // Частота синусоиды
    //private Vector3 _startPos;

    protected override void Fly()
    {
        if (_target != null)
        {
            //Vector3 directionToTarget = (targetBeeObject.transform.position - transform.position).normalized;
            //Vector3 newPosition = transform.position + directionToTarget * _flightSpeed * Time.deltaTime;
            //transform.position = newPosition;
            this.transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, base._flightSpeed * Time.deltaTime);
        }
        //else
        //{
        //    // Вычисляем новую позицию по синусоиде
        //    float yOffset = _amplitude * Mathf.Sin(_frequency * Time.time * _flightSpeed);
        //    Vector3 newPosition = _startPos + new Vector3(0f, yOffset, 0f);

        //    // Применяем новую позицию
        //    transform.position = newPosition;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<Hive>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive")
        {
            Destroy(this.gameObject);
        }
    }
}
