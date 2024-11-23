using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seven : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Seven;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 7 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 7 Block");
    }
}
