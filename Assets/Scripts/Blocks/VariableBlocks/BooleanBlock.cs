using UnityEngine;

public class BooleanVariableBlock : VariableBlock
{
    protected override string Symbol => Value;
    private void Start()
    {
        VariableType = VariableType.Boolean;
        Value = "true";
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Boolean Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Boolean Variable Block");
    }
}
