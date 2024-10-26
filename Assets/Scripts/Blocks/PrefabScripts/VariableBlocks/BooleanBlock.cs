using UnityEngine;

public class BooleanVariableBlock : VariableBlock
{
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
