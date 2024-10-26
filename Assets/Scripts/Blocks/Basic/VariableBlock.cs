using UnityEngine;

public abstract class VariableBlock : Block, IVariableBlock
{
    // Properties for variable block; set in derived classes
    public string Value { get; protected set; }
    public VariableType VariableType { get; protected set; }

    private void Start()
    {
        Type = BlockType.VariableBlock;
    }

    public override void Spawn()
    {
        // Common spawn logic for variable blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for variable blocks (if any)
    }
}
