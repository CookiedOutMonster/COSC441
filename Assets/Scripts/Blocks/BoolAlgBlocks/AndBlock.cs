// AndBlock.cs
using UnityEngine;

public class AndBlock : BoolAlgBlock
{
    protected override string Symbol => "&";
    private void Start()
    {
        BooleanOperation = BooleanOperation.And;
        Spawn();
    }
    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning AND Boolean Algebra Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting AND Boolean Algebra Block");
    }
}
