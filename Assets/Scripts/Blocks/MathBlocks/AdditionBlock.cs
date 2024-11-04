using UnityEngine;

public class AdditionBlock : MathBlock
{
    private void Start()
    {
        base.Start();
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
