// NotEqualAssignmentBlock.cs
using UnityEngine;

public class NotEqualsBlock : AssignmentBlock
{
    private void Start()
    {
        Type = BlockType.AssignmentBlock;
        AssignmentType = AssignmentType.NotEqual;
    }
}
