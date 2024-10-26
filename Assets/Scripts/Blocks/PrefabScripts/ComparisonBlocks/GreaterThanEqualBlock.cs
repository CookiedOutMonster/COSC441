using UnityEngine;

public class GreaterThanEqualBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.GreaterThanEqual;
    }
}