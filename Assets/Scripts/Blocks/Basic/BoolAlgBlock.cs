using UnityEngine;

public abstract class BoolAlgBlock : Block, IBoolAlgBlock
{
    // Property for Boolean operation; set in derived classes
    public BooleanOperator BooleanOperator { get; protected set; }

    private void Start()
    {
        Type = BlockType.BoolAlgBlock;
    }

    public override void Spawn()
    {
        // Common spawn logic for boolean logic blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for boolean logic blocks (if any)
    }
}
