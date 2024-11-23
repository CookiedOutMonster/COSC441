using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.C;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning C Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting C Block");
    }
}
