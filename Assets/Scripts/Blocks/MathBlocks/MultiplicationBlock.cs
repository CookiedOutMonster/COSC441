using UnityEngine;

public class MultiplicationBlock : MathBlock
{
    private void Start()
    {
        MathOperation = MathOperation.Multiplication;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Multiplication Math Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Multiplication Math Block");
    }
}
