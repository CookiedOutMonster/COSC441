using UnityEngine;

public abstract class ComparisonBlock : Block, IComparisonBlock
{
    // Property for Comparison type; set in derived classes
    public ComparisonType ComparisonType { get; protected set; }

    private void Start()
    {
        Type = BlockType.ComparisonBlock;
    }

    public override void Spawn()
    {
        // Common spawn logic for comparison blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for comparison blocks (if any)
    }
}
