using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.B;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning B Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting B Block");
    }
}
