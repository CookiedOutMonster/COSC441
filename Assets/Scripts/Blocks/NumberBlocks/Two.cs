using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : NumberBlock
{
    private void Start()
    {
        base.Start();
        Number = Number.Two;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning 2 Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting 2 Block");
    }
}
