using UnityEngine;

public class Sunflower : Flower
{
    [SerializeField]
    private GameObject _pollen;

    // Start is called before the first frame update
    void Start()
    {
        _maxPollenCount = 3;
        SpawnPollens(_pollen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
