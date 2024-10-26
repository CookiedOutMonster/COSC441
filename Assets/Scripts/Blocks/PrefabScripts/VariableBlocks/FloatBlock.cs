using UnityEngine;

public class FloatVariableBlock : VariableBlock
{
    private void Start()
    {
        // Set the block type and variable type specific to this block
        Type = BlockType.VariableBlock;
        VariableType = VariableType.Float;
        
        // Initialize the Value to a default boolean value, like "true" or "false"
        Value = "0.00";
    }

    public override void Spawn()
    {
        // Custom spawn logic for BooleanVariableBlock, if needed
        Debug.Log("Spawning Float Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        // Custom delete logic for BooleanVariableBlock, if needed
        Debug.Log("Deleting Float Variable Block");
    }
}
