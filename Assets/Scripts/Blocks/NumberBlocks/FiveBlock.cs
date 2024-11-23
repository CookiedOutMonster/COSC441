using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveBlock : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Five;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 5 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 5 Block");
    }
}
