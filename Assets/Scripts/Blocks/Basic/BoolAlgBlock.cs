using UnityEngine;
     public enum BooleanOperation
    {
        And,
        Or,
        Not
    }
public abstract class BoolAlgBlock : Block
{
    // Property for Boolean operation; set in derived classes
    public BooleanOperation BooleanOperation { get; protected set; }
    public override Color BlockColor => Color.yellow;

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
