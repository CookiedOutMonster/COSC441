using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBlock : TextBlock
{
    private void Start()
    {
        base.Start();
        Text Text = Text.Y;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Y Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Y Block");
    }
}
