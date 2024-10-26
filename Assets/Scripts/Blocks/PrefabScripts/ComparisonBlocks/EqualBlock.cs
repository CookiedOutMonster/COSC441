// EqualBlock.cs
using UnityEngine;

public class EqualBlock : ComparisonBlock
{
    private void Start()
    {
        ComparisonType = ComparisonType.Equal;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Equal Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Equal Comparison Block");
    }
}

