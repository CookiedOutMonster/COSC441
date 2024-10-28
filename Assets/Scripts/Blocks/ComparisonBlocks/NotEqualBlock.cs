using UnityEngine;

public class NotEqualBlock : ComparisonBlock
{
    protected override string Symbol => "!=";
    private void Start()
    {
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