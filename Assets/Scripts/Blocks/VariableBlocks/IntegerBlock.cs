using UnityEngine;

public class IntegerVariableBlock : VarTypeBlock
{
    private void Start()
    {
        base.Start();
        VariableType = VariableType.Integer;
        Spawn();
    }



    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Integer VarType Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Integer VarType Block");
    }
}