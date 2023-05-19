using UnityEngine;

public class BeeRecycler : Bee
{
    private  static int _beeRecyclerCounter;
    public static int BeeRecyclerCounter
    {
        get { return _beeRecyclerCounter; }
        set { _beeRecyclerCounter = value; }
    }

    [SerializeField] private int _productionEfficiency;
    [SerializeField] private int _NPR; //nectar processing rate

    private void Start()
    {

    }

    private void Update()
    {

    }

    protected override void Fly()
    {
        // soon
    }

    public void ProcessNectar()
    {
        // soon
    }
}
