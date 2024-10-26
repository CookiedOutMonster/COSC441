// EqualBlock.cs
using UnityEngine;

public class EqualBlock : ComparisonBlock
{
    private void Start()
    {
        Type = BlockType.ComparisonBlock;
        ComparisonType = ComparisonType.Equal;
    }
}

