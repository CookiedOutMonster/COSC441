using UnityEngine;
public enum BlockType
{
    VariableBlock,
    ComparisonBlock,
    BoolAlgBlock,
    AssignmentBlock,
    MathBlock
}

// Interface for general block functionality
public interface IBlock
{
    void Spawn();    // Method to spawn the block in the scene
    void Delete();   // Method to delete the block from the scene
}

// Abstract base class for all block types
public abstract class Block : MonoBehaviour, IBlock
{
    public BlockType Type { get; protected set; }

    public abstract void Spawn();
    public abstract void Delete();
}
