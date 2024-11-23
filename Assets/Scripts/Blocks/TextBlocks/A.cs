using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.A;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning A Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting A Block");
    }
}
