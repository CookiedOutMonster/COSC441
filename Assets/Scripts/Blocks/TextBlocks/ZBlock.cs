using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBlock : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.Z;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Z Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Z Block");
    }
}
