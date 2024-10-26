using UnityEngine;

public abstract class MathBlock : Block, IMathBlock
{
    // Property for Math Operation type
    public MathOperation MathOperation { get; protected set; }

    private void Start()
    {
        Type = BlockType.MathBlock;
    }

    public override void Spawn()
    {
        // Common spawn logic for math blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for math blocks (if any)
    }
}
