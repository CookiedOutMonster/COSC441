using UnityEngine;

public class StringVariableBlock : VariableBlock
{
    private void Start()
    {
        base.Start()
        VariableType = VariableType.String;
        Value = "null";
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning String Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting String Variable Block");
    }
}
