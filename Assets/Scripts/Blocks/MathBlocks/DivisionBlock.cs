using UnityEngine;

public class DivisionBlock : MathBlock
{
    protected override string Symbol => "/";
    private void Start()
    {
        MathOperation = MathOperation.Division;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Division Math Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Division Math Block");
    }
}
