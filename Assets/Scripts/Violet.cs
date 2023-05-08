using UnityEngine;

public class Violet : Flower
{
    [SerializeField]
    private GameObject _pollen;

    // Start is called before the first frame update
    void Start()
    {
        _maxPollenCount = 2;
        SpawnPollens(_pollen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
