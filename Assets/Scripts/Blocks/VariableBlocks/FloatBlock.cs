using UnityEngine;

public class FloatVariableBlock : VariableBlock
{
    private void Start()
    {
        base.Start();
        VariableType = VariableType.Float;
        Value = "0.00";
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Float Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Float Variable Block");
    }
}
