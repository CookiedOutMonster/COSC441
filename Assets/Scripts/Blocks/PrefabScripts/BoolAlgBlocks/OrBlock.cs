
// OrBlock.cs
using UnityEngine;

public class OrBlock : BoolAlgBlock
{
    private void Start()
    {
        Type = BlockType.BoolAlgBlock;
        BooleanOperator = BooleanOperator.Or;
    }
}