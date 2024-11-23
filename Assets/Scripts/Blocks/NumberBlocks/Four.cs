using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Four : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Four;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 4 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 4 Block");
    }
}
