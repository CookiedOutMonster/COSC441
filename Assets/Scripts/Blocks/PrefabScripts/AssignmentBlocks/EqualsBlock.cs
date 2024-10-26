// EqualAssignmentBlock.cs
using UnityEngine;

public class EqualsBlock : AssignmentBlock
{
    private void Start()
    {
        Type = BlockType.AssignmentBlock;
        AssignmentType = AssignmentType.Equal;
    }
}
