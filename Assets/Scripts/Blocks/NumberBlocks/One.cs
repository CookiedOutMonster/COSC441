using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.One;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 1 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 1 Block");
    }
}
