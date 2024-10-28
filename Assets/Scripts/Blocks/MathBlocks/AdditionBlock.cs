using UnityEngine;

public class AdditionBlock : MathBlock
{
    protected override string Symbol => "+";
    private void Start()
    {
        MathOperation = MathOperation.Addition;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Addition Math Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Addition Math Block");
    }
}
