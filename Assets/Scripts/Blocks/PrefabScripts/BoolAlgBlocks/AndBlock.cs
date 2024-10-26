// AndBlock.cs
using UnityEngine;

public class AndBlock : BoolAlgBlock
{
    private void Start()
    {
        Type = BlockType.BoolAlgBlock;
        BooleanOperator = BooleanOperator.And;
    }
}
