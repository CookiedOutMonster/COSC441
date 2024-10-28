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

    // Default color, can be overridden in derived classes
    public override Color BlockColor => Color.yellow;
    protected override string Symbol => "?";

    private void Start()
    {
        Type = BlockType.BoolAlgBlock;
    }

    public override void Spawn()
    {
        // Set color on spawn
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = BlockColor;
        }

        AddSymbolToSides();
        // Common spawn logic for boolean logic blocks
    }

    public override void Delete()
    {
        // Common delete logic for boolean logic blocks
    }
}
