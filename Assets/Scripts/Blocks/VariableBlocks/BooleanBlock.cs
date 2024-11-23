using UnityEngine;

public class BooleanVariableBlock : VarTypeBlock
{
    private void Start()
    {
        base.Start();
        VariableType = VariableType.Boolean;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Boolean VarType Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Boolean VarType Block");
    }
}
