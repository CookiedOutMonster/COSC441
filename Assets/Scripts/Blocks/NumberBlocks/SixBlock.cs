using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixBlock : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Six;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 6 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 6 Block");
    }
}
