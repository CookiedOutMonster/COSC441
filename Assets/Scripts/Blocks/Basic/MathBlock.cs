using UnityEngine;

    public enum MathOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
public abstract class MathBlock : Block
{
    // Property for Math Operation type
    public MathOperation MathOperation { get; protected set; }
    public override Color BlockColor => Color.green;
    protected override string Symbol => "?";

    private void Start()
    {
        Type = BlockType.MathBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = BlockColor;
        }
        AddSymbolToSides();
        // Common spawn logic for math blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for math blocks (if any)
    }
}
