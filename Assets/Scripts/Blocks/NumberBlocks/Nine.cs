using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nine : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Nine;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 9 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 9 Block");
    }
}
