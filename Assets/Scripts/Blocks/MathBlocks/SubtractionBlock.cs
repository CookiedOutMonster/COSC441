using UnityEngine;

public class SubtractionBlock : MathBlock
{
    protected override string Symbol => "-";
    private void Start()
    {
        MathOperation = MathOperation.Subtraction;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Subtraction Math Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Subtraction Math Block");
    }
}
