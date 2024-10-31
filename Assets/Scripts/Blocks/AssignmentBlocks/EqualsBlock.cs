// EqualAssignmentBlock.cs
using UnityEngine;

public class EqualsBlock : AssignmentBlock
{
    private void Start()
    {
        AssignmentType = AssignmentType.Equals;
        Spawn();
    }public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Equals Assignment Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Equals Assignment Block");
    }
}
