using UnityEngine;

public class GreaterThanEqualBlock : ComparisonBlock
{
    protected override string Symbol => ">=";
    private void Start()
    {
        ComparisonType = ComparisonType.GreaterThanEqual;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Greater Than or Equal Comparison Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Greater Than or Equal Comparison Block");
    }
}