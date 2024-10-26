// MultiplicationBlock.cs
using UnityEngine;

public class MultiplicationBlock : MathBlock
{
    private void Start()
    {
        Type = BlockType.MathBlock;
        MathOperation = MathOperation.Multiplication;
    }
}