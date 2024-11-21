using UnityEngine;

public class NotEqualBlock : ComparisonBlock
{
    private void Start()
    {
        base.Start();
        ComparisonType = ComparisonType.NotEqual;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Not Equal Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Not Equal Comparison Block");
    }
}