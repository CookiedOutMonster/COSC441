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

    private void Start()
    {
        Type = BlockType.MathBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for math blocks (if any)
    }
}
