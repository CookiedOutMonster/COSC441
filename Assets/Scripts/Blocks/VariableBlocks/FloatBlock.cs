using UnityEngine;

public class FloatVariableBlock : VarTypeBlock
{
    private void Start()
    {
        base.Start();
        VariableType = VariableType.Float;
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();
        Debug.Log("Spawning Float VarType Block");
    }

    public override void Delete()
    {
        base.Delete();
        Debug.Log("Deleting Float VarType Block");
    }
}
