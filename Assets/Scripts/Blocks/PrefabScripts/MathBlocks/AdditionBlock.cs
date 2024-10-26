// AdditionBlock.cs
using UnityEngine;

public class AdditionBlock : MathBlock
{
    private void Start()
    {
        Type = BlockType.MathBlock;
        MathOperation = MathOperation.Addition;
    }
}