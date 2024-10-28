using UnityEngine;

public class IntegerVariableBlock : VariableBlock
{
    protected override string Symbol => Value;
    private void Start()
    {
        VariableType = VariableType.Integer;
        Value = "0";
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Integer Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Integer Variable Block");
    }
}