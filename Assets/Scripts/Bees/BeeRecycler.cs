using UnityEngine;

public class BeeRecycler : Bee
{
    private int _beeRecyclerObjectsCount;
    private int _productionEfficiency;
    private int _NPR; //nectar processing rate (�������� ����������� �������)

    public override void Fly()
    {
        // ����������� �����!
    }

    public void ProcessNectar()
    {
        // ����������� �����!
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
