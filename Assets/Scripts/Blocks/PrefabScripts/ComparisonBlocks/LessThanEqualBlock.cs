using UnityEngine;

public class LessThanEqualBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.LessThanEqual;
    }
}