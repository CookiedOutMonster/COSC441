using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.X;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning X Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting X Block");
    }
}
