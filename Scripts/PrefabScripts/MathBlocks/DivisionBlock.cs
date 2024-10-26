// DivisionBlock.cs
using UnityEngine;

public class DivisionBlock : MathBlock
{
    private void Start()
    {
        Type = BlockType.MathBlock;
        MathOperation = MathOperation.Division;
    }
}