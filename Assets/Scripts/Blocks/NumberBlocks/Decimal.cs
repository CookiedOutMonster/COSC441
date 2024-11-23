using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decimal : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Decimal;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Decimal Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Decimal Block");
    }
}
