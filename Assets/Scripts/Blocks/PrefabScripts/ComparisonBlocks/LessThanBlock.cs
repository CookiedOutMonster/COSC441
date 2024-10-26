// LessThanBlock.cs
using UnityEngine;

public class LessThanBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.LessThan;
    }
}