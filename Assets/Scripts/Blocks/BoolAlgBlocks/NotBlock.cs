// NotBlock.cs
using UnityEngine;

public class NotBlock : BoolAlgBlock
{
    private void Start()
    {
        base.Start();
        BooleanOperation = BooleanOperation.Not;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning NOT Boolean Algebra Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting NOT Boolean Algebra Block");
    }
}