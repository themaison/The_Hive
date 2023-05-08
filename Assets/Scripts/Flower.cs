using Unity.VisualScripting;
using UnityEngine;

public abstract class Flower : StaticObject
{
    protected static int _flowersCount = 0;
    protected int _maxPollenCount;
    protected int _pollenCount;

    public int FlowersCount
    {
        get { return _flowersCount; }
        set { _flowersCount = value; }
    }

    protected void SpawnPollens(GameObject pollen)
    {
        _pollenCount = GetRandPollenCount();
        for (int i = 0; i < _pollenCount; ++i)
        {
            var obj = Instantiate(pollen, this.transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.transform.localPosition = GetRandPollenPosition();
        }
    }

    protected int GetRandPollenCount()
    {
        return Random.Range(1, _maxPollenCount + 1);
    }

    private Vector2 GetRandPollenPosition()
    {
        float randX = Random.Range(-0.25f, 0.25f);
        float randY = Random.Range(0f, 0.3f);
        return new Vector2(randX, randY);
    }
}
