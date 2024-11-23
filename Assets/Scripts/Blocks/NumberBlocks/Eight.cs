using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eight : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Eight;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 8 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 8 Block");
    }
}
