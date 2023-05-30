using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeRecyclerBuyer : BeeBuyingSystem
{
    void Update()
    {
        UpdateBuyButton();
    }

    public override void Buy()
    {
        base.Buy();
        _beeSpawner.SpawnRecycler();
    }
}
