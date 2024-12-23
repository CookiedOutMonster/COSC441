// GreaterThanBlock.cs
using UnityEngine;

public class GreaterThanBlock : ComparisonBlock
{
    private void Start()
    {
        base.Start();
        ComparisonType = ComparisonType.GreaterThan;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Greater Than Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Greater Than Comparison Block");
    }
}