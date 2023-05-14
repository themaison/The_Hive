using UnityEngine;

public class Wasp : Enemy
{

    private void Start()
    {
        _target = FindObjectOfType<Hive>().gameObject;
    }

    private void FixedUpdate()
    {
        Fly();
    }

    protected override void Fly()
    {
        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flightSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hive")
        {
            //collision.GetComponent<Hive>()
            Destroy(this.gameObject);
        }
    }
}
