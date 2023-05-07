using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chamomileObj;
    [SerializeField]
    private GameObject violetObj;
    [SerializeField]
    private GameObject sunflowerObj;
    [SerializeField]
    [Range(1, 10)]
    private float forbiddenRadius;
    [SerializeField]
    [Range(2, 15)]
    private float maxRadius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
