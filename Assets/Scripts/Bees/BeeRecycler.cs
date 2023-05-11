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
    [SerializeField] private int _NPR; //nectar processing rate (скорость переработки нектара)

    protected override void Fly()
    {
        // РЕАЛИЗОВАТЬ СУЧКИ!
    }

    public void ProcessNectar()
    {
        // РЕАЛИЗОВАТЬ СУЧКИ!
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
