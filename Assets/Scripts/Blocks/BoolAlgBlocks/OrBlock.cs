
// OrBlock.cs
using UnityEngine;

public class OrBlock : BoolAlgBlock
{
    private void Start()
    {
        BooleanOperation = BooleanOperation.Or;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning OR Boolean Algebra Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting OR Boolean Algebra Block");
    }
}