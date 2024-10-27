using UnityEngine;
     public enum ComparisonType
    {
        NotEqual,
        Equal,
        LessThan,
        LessThanEqual,
        GreaterThan,
        GreaterThanEqual
        
    }
public abstract class ComparisonBlock : Block
{
    // Property for Comparison type; set in derived classes
    public ComparisonType ComparisonType { get; protected set; }
    public override Color BlockColor => Color.purple;

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