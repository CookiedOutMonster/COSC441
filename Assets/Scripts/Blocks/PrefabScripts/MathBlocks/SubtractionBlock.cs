
// SubtractionBlock.cs
using UnityEngine;

public class SubtractionBlock : MathBlock
{
    private void Start()
    {
        Type = BlockType.MathBlock;
        MathOperation = MathOperation.Subtraction;
    }
}
