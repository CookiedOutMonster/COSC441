using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBlock : TrueFalseBlock
{
    private void Start()
    {
        base.Start();
        Value Value = Value.True;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning True Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting True Block");
    }
}
