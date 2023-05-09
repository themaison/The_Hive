using UnityEngine;

public class Chamomile : Flower
{
    // Start is called before the first frame update
    void Start()
    {
        _maxPollenCount = 1;
        SpawnPollens(_pollen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
