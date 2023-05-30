using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePollinatorBuyer : BeeBuyingSystem
{
    void Update()
    {
        UpdateBuyButton();
    }

    public override void Buy()
    {
        base.Buy();
        _beeSpawner.SpawnPollinator();
    }
}
