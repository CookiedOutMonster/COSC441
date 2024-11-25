using UnityEngine;

public class StringVariableBlock : VarTypeBlock
{
    private void Start()
    {
        base.Start();
        VariableType = VariableType.String;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning String VarType Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting String Variable Block");
    }
}
