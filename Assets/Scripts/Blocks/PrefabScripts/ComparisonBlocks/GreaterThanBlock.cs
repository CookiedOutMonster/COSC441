// GreaterThanBlock.cs
using UnityEngine;

public class GreaterThanBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.GreaterThan;
    }
}