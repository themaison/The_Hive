using UnityEngine;

public class Wasp : Enemy
{
    public float amplitude = 1f;  // Амплитуда синусоиды
    public float frequency = 1f;  // Частота синусоиды
    public float speed = 1f;      // Скорость движения
    private Vector3 startPos;

    public override void Fly()
    {
        if (targetBeeObject != null)
        {
            // Вычисляем направление к целевому объекту
            Vector3 directionToTarget = (targetBeeObject.transform.position - transform.position).normalized;

            // Вычисляем новую позицию, двигаясь в направлении цели
            Vector3 newPosition = transform.position + directionToTarget * speed * Time.deltaTime;

            // Применяем новую позицию
            transform.position = newPosition;
        }
        else
        {
            // Вычисляем новую позицию по синусоиде
            float yOffset = amplitude * Mathf.Sin(frequency * Time.time * speed);
            Vector3 newPosition = startPos + new Vector3(0f, yOffset, 0f);

            // Применяем новую позицию
            transform.position = newPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
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
