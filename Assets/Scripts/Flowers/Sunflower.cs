using UnityEngine;

public class Sunflower : Flower
{
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
