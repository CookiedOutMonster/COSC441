using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeBlock : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Three;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 3 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 3 Block");
    }
}
