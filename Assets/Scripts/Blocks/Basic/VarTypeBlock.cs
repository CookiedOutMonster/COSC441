using UnityEngine;

public enum VariableType
{
    Boolean,
    Float,
    Integer,
    String
}
public abstract class VarTypeBlock : Block
{
    // Properties for variable block; set in derived classes
    // A VarTypeBlock does NOT store values, it only sets type; a different block altogether is used to represent actual value
    public VariableType VariableType { get; protected set; }

    protected void Start()
    {
        base.Start();
        Type = BlockType.VarTypeBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for variable blocks (if any)
    }
}
