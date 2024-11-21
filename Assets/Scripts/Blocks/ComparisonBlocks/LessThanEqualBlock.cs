using UnityEngine;

public class LessThanEqualBlock : ComparisonBlock
{
    private void Start()
    {
        base.Start();
        ComparisonType = ComparisonType.LessThanEqual;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Less Than or Equal Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Less Than or Equal Comparison Block");
    }
}