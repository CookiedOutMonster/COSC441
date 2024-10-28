// NotEqualAssignmentBlock.cs
using UnityEngine;

public class NotEqualsBlock : AssignmentBlock
{
    protected override string Symbol => "!";
    private void Start()
    {
        AssignmentType = AssignmentType.NotEquals;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Not Equals Assignment Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Not Equals Assignment Block");
    }
}
