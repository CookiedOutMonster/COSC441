using UnityEngine;

public class NotEqualBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.NotEqual;
    }
}