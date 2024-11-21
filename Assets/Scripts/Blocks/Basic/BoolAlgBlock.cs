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

    protected void Start()
    {
        base.Start();
        Type = BlockType.BoolAlgBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for boolean logic blocks
    }
}
