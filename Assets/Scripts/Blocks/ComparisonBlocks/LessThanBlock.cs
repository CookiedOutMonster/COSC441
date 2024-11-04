// LessThanBlock.cs
using UnityEngine;

public class LessThanBlock : ComparisonBlock
{
    private void Start()
    {
        base.Start();
        ComparisonType = ComparisonType.LessThan;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Less Than Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Less Than Comparison Block");
    }
}