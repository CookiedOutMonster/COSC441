using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class False : TrueFalseBlock
{
    private void Start()
    {
        base.Start();
        Value Value = Value.False;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning False Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting False Block");
    }
}
