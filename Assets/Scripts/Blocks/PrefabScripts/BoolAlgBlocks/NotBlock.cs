// NotBlock.cs
using UnityEngine;

public class NotBlock : BoolAlgBlock
{
    private void Start()
    {
        Type = BlockType.BoolAlgBlock;
        BooleanOperator = BooleanOperator.Not;
    }
}